using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Identity.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential {get;set;}
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if(Credential.UserName =="admin" && Credential.Password=="password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                    new Claim("Department","HR"),
                    new Claim("Admin","true"),
                    new Claim("Manager","true"),
                    new Claim("EmploymentDate","2021-04-22")
                };
                var identity = new ClaimsIdentity(claims,"MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);                

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = Credential.RememberMe
                };

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal,authProperties);

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }   
}
