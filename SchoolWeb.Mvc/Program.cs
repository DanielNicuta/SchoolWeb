using Microsoft.Extensions.Options;
using SchoolWeb.Application.Contracts.Public;
using SchoolWeb.Application.Options;
using SchoolWeb.Infrastructure.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services
    .AddOptions<ApiOptions>()
    .Bind(builder.Configuration.GetSection(ApiOptions.SectionName))
    .ValidateOnStart();

builder.Services.AddSingleton<IValidateOptions<ApiOptions>, ApiOptionsValidator>();

builder.Services.AddHttpClient<IApiClient, ApiClient>((sp, client) =>
{
    var options = sp.GetRequiredService<IOptions<ApiOptions>>().Value;

    client.BaseAddress = new Uri(options.BaseUrl);
    client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
});

builder.Services.AddScoped<IPublicContentClient, PublicContentClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
