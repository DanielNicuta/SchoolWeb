using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Mvc.Areas.Admin.Models;

public sealed class AdminLoginVm
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
