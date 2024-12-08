using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using backend.Models;
using backend.Data;
using System.Globalization;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelperController : ControllerBase
{
    private readonly FileDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _rm;
    

    public HelperController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> rm, AppDbContext db)
    {
        _userManager = userManager;
        _db = db;
        _rm = rm;
    }

    // TODO test

    [HttpPost("AddFile")]
    // TODO see if helpee belongs here
    [Authorize(Roles = "Helper,Admin, Helpee")]
    public IActionResult AddFile([FromFile] LoginDto model)
    {
        // TODO implement
        
    }

    [HttpGet("GetFile")]
    // TODO see if helpee belongs here
    [Authorize(Roles = "Helper,Admin, Helpee")]
    public IActionResult GetFile(string FileName)
    {
        // TODO implement
        
    }
}