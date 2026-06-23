using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticMVP.Controllers;

[Route("LogisticMVP/Admin")]
[Authorize]
public class AdminController : Controller
{
    public IActionResult Admin()
    {
        return View();
    }
}