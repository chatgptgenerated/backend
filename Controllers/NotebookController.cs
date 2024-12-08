using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using backend.Models;
using backend.Data;
using System.Globalization;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotebookController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _rm;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public NotebookController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> rm, AppDbContext db)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _db = db;
        _rm = rm;
    } 
 
    [HttpGet("Notebooks")]
    public IActionResult GetAllHelped([FromQuery] string HelpeeId)
    {
        // TOOD get first and last name
        var notebookNames = _db.HelpeeNotebook.Where(x => x.HelpeeId == HelpeeId).Select(x => x.Notebook.NotebookName).ToArray();

        return Ok(notebookNames);
    }
}