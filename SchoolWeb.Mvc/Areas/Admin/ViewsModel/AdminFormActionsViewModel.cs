namespace SchoolWeb.Mvc.Areas.Admin.ViewsModel;

public sealed class AdminFormActionsViewModel
{
    public string SaveText { get; init; } = "Save";
    public string HelpText { get; init; } = "Review your changes before saving.";
    public string? PreviewUrl { get; init; }
    public string? BackUrl { get; init; }
}