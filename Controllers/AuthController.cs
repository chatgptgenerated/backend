using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using backend.Models;
using backend.Data;
using System.Formats.Asn1;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext db)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _db = db;
    }

    // Registration Endpoint
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        Console.WriteLine("am intrat in register");
        if (!ModelState.IsValid){
            Console.WriteLine("ceva nu e bine!");
            return BadRequest(ModelState);
        }

        Console.WriteLine("am trecut la guid");
        Guid ProfileToken = Guid.NewGuid();
        String token = ProfileToken.ToString().Substring(0, 8);

        var user = new ApplicationUser
        {
            UserName = model.Email,
            ProfileToken = token,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PreferedLanguage = model.PreferedLanguage,
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(new { Message = "User registered successfully" });
    }

    // Login Endpoint
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        Console.WriteLine("Am intrat in Login");
        if (!ModelState.IsValid){
            Console.WriteLine("Am intrat in modelstate");
            return BadRequest(ModelState);
        }

        Console.WriteLine(model.Email);
        Console.WriteLine(model.Password);
        Console.WriteLine(model.RememberMe);

        Console.WriteLine("before signin");
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

        
        if (!result.Succeeded)
            return Unauthorized(new { Message = "Invalid login attempt" });

        return Ok(new { Message = "Logged in successfully" });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok(new { Message = "Logged out successfully" });
    }

    // TODO we can refactor into a more general thing
    [HttpGet("getIdentity")]
    public async Task<IActionResult> GetIdentity(){
        
        if (User.Identity.IsAuthenticated) {
            Console.WriteLine(User.Identity.Name);
            return Ok(new { Message = _userManager.GetUserId(User) });
        } else {
            return Ok(new { Message = "nay" }); 
        }
    }

    [HttpGet("getId")]
    public async Task<IActionResult> GetId() {
        return Ok(_userManager.GetUserId(User));
    }
}
