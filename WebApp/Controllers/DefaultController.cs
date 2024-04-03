using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class DefaultController : Controller
{
    public IActionResult Home()
    {
        return View();
    }
}
