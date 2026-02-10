namespace SchoolWeb.Application.Contracts.Pages;

/// <summary>
/// Generic CMS page container (shape will be refined to match API).
/// Start generic to avoid guessing fields.
/// </summary>
public sealed class CmsPageDto
{
    public string Name { get; init; } = string.Empty;
    public string? Title { get; init; }

    // Common CMS approach: store page content as JSON fields/sections.
    // We'll replace with strongly typed models after confirming exact API schema.
    public Dictionary<string, object>? Content { get; init; }
}
