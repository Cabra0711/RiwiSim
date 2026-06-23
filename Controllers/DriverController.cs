using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticMVP.Controllers;

[Route("LogisticMVP/Driver")]
[Authorize]
public class DriverController : Controller
{
    public IActionResult Driver()
    {
        return View();
    }
}