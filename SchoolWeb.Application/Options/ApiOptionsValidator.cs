using Microsoft.Extensions.Options;

namespace SchoolWeb.Application.Options;

public sealed class ApiOptionsValidator : IValidateOptions<ApiOptions>
{
    public ValidateOptionsResult Validate(string? name, ApiOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.BaseUrl))
            return ValidateOptionsResult.Fail($"{ApiOptions.SectionName}:BaseUrl is required.");

        if (!Uri.TryCreate(options.BaseUrl, UriKind.Absolute, out _))
            return ValidateOptionsResult.Fail($"{ApiOptions.SectionName}:BaseUrl must be a valid absolute URL.");

        if (options.TimeoutSeconds < 5 || options.TimeoutSeconds > 300)
            return ValidateOptionsResult.Fail($"{ApiOptions.SectionName}:TimeoutSeconds must be between 5 and 300.");

        return ValidateOptionsResult.Success;
    }
}
