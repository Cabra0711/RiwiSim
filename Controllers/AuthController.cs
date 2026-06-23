using LogisticMVP.Enums;
using LogisticMVP.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticMVP.Controllers;

[Route("LogisticMVP")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpGet("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async  Task<IActionResult> Login(string email, string password)
    {
        var response = await _authService.Login(email, password);

        if (response.Success)
        {
            HttpContext.Session.SetString("Email", email);
            if (!string.IsNullOrEmpty(response.Data.Token))
            {
                HttpContext.Session.SetString("Token", response.Data.Token);
            }

            if (response.Data.Role == UserRole.Client)
            {
                return RedirectToAction("User", "User");
            }else if (response.Data.Role == UserRole.Admin)
            {
                return RedirectToAction("Driver",  "Driver");
            }
            else
            {
                return RedirectToAction("Admin", "Admin");
            }
            
        }
        ViewBag.Error = response?.Message ?? "Credenciales incorrectas o invalidas intente de nuevo porfavor.";
        return View();
    }
}