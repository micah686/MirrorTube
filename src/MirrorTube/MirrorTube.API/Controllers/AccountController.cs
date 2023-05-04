using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MirrorTube.API.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("/api/v1/register")]
        [HttpPost]
        public async Task<AuthResponse> Register(RegisterModel model)
        {
            AuthResponse operationState = new AuthResponse();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //await _signInManager.SignInAsync(user, isPersistent: false);

                    //return RedirectToAction("index", "Home");
                    return new AuthResponse() { Success = true };
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    operationState = new AuthResponse() { Success = false, ErrorMessage = error.Description };
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return operationState;
        }

        public struct AuthResponse
        {
            public bool Success { get; set; }
            public string? ErrorMessage { get; set; }
        }

        public class RegisterModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "User Name")]
            public string UserName { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
    }
}
