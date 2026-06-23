using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticMVP.Controllers;

[Route("LogisticMVP/Client")]
[Authorize]
public class UserController : Controller
{
    public IActionResult User()
    {
        return View();
    }
}