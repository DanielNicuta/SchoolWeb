using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolWeb.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize] // or your admin policy
public class MediaController : Controller
{
    private readonly IWebHostEnvironment _env;
    private static readonly HashSet<string> AllowedContentTypes = new(StringComparer.OrdinalIgnoreCase)
    {
        "image/png","image/jpeg","image/webp","image/gif"
    };

    public MediaController(IWebHostEnvironment env) => _env = env;

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upload(IFormFile file, CancellationToken ct)
    {
        if (file is null || file.Length == 0) return BadRequest(new { error = "No file selected." });
        if (!AllowedContentTypes.Contains(file.ContentType)) return BadRequest(new { error = "Unsupported file type." });
        if (file.Length > 5 * 1024 * 1024) return BadRequest(new { error = "Max 5MB." });

        var uploadsDir = Path.Combine(_env.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadsDir);

        var ext = Path.GetExtension(file.FileName);
        var safeName = $"{Guid.NewGuid():N}{ext}";
        var physicalPath = Path.Combine(uploadsDir, safeName);

        await using var stream = System.IO.File.Create(physicalPath);
        await file.CopyToAsync(stream, ct);

        var url = Url.Content($"~/uploads/{safeName}");
        return Ok(new { url });
    }

    // Optional: list existing images for “Choose existing”
    [HttpGet]
    public IActionResult List()
    {
        var uploadsDir = Path.Combine(_env.WebRootPath, "uploads");
        if (!Directory.Exists(uploadsDir)) return Ok(Array.Empty<string>());

        var files = Directory.EnumerateFiles(uploadsDir)
            .Select(Path.GetFileName)
            .Where(name => name is not null)
            .Select(name => Url.Content($"~/uploads/{name}"))
            .OrderByDescending(x => x)
            .Take(200);

        return Ok(files);
    }
}