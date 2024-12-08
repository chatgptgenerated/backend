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
    private readonly AppDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _rm;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public HelperController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> rm, AppDbContext db)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _db = db;
        _rm = rm;
    }

    // TODO test

    [HttpPost("AddHelp")]
    // TODO see if helpee belongs here
    [Authorize(Roles = "Helper,Admin")]
    public IActionResult AddHelp(string HelpeeToken)
    {

        var helpeeWithToken = _db.Users.Where(us => us.ProfileToken == HelpeeToken);
        var user = _db.Users.Where(us => us.Id == _userManager.GetUserId(User));

        if (helpeeWithToken.Any())
        {
            var HelpedProfile = user.First();
            // verifica ca nu e ajutat deja
            var relation = _db.AidHelpee.Where(us => us.HelpedProfile.ProfileToken == HelpeeToken);
            if (relation.Any()){
                return BadRequest();
            }

            AidHelpee newreq = new AidHelpee { HelpingProfileId = _userManager.GetUserId(User), HelpedProfileId = HelpedProfile.Id};
            _db.AidHelpee.Add(newreq);
            _db.SaveChanges();
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost("RemoveHelp")]
    // TODO see if helpee belongs here
    [Authorize(Roles = "Helper,Admin")]
    public IActionResult RemoveHelp(string HelpeeToken)
    {

        var helpeeWithToken = _db.Users.Where(us => us.ProfileToken == HelpeeToken);
        var user = _db.Users.Where(us => us.Id == _userManager.GetUserId(User));

        if (helpeeWithToken.Any())
        {
            var HelpedProfile = user.First();
            // verifica ca nu e ajutat deja
            var relation = _db.AidHelpee.Where(us => us.HelpedProfile.ProfileToken == HelpeeToken);
            if (relation.Any()){
                return BadRequest();
            }

            AidHelpee newreq = new AidHelpee { HelpingProfileId = _userManager.GetUserId(User), HelpedProfileId = HelpedProfile.Id};
            _db.AidHelpee.Add(newreq);
            _db.SaveChanges();
            return Ok();
        }

        return BadRequest();
    }

    [HttpGet("AllHelped")]
    // TODO see if helpee belongs here
    [Authorize(Roles = "Helper,Admin")]
    public IActionResult GetAllHelped(string HelperId)
    {
        // TOOD get first and last name
        var helpeeIds = _db.AidHelpee.Where(x => x.HelpingProfileId == HelperId).Select(x => new {FullName = x.HelpedProfile.FirstName + " " + x.HelpedProfile.LastName}).ToArray();

        return Ok(helpeeIds);
    }
}