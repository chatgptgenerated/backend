using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using backend.Models;
using backend.Data;
using Microsoft.AspNetCore.StaticFiles;
using System.Globalization;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly FileDbContext _db;
    private readonly AppDbContext appdb;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _rm;
    

    public FileController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> rm, FileDbContext db, AppDbContext appdb)
    {
        _userManager = userManager;
        _db = db;
        _rm = rm;
        appdb = appdb;
    }

    // TODO test

    // TODO add uploader & destination to table in appDbContext
    [HttpPost("AddFile")]
    // TODO see if helpee belongs here
    public async Task<IActionResult> AddFile([FromForm] IFormFile file)
    {
        Console.WriteLine("am intrat");
        Console.WriteLine(file);

        var provider = new FileExtensionContentTypeProvider();
        provider.TryGetContentType(file.FileName, out var contentType);
        if (file == null || file.Length == 0)
        {
            Console.WriteLine("nu am gasit fisier");
            return BadRequest("No file uploaded.");
        }

        byte[] fileContent;
        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            fileContent = memoryStream.ToArray();
        }
        Console.WriteLine("inca ceva");

        var fileModel = new FileModel { Name = file.FileName, Data = fileContent, Type = contentType};

        _db.FileModels.Add(fileModel);
        _db.SaveChanges();

        return Ok(new { Message = "File uploaded successfully.", FileName = file.FileName });
        
    }

    [HttpGet("GetFile")]
    // TODO see if helpee belongs here
    public IActionResult GetFile([FromForm] string FileName)
    {

        // TODO implement
        //return Ok();

        var fileContent = _db.FileModels.Where(x => x.Name == FileName).Select(x => x).First();

        Console.WriteLine(fileContent);
        return File(fileContent.Data, fileContent.Type, fileContent.Name);
        
    }
}