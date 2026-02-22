using Microsoft.Extensions.Options;
using SchoolWeb.Application.Contracts.Auth;
using SchoolWeb.Application.Contracts.Pages;
using SchoolWeb.Application.Contracts.Public;
using SchoolWeb.Application.Options;
using SchoolWeb.Infrastructure.Auth;
using SchoolWeb.Infrastructure.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddMemoryCache();


builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromHours(8);
});


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

builder.Services.AddScoped<ITokenStore, SessionTokenStore>();
builder.Services.AddScoped<IAuthClient, AuthClient>();

builder.Services.AddScoped<IPageClient, PageClient>();
builder.Services.AddScoped<IAdminPageClient, AdminPageClient>();


// Handler for authorized API calls
builder.Services.AddTransient<ApiAuthHandler>();

builder.Services.AddHttpClient<IAdminApiClient, AdminApiClient>((sp, client) =>
{
    var options = sp.GetRequiredService<IOptions<ApiOptions>>().Value;
    client.BaseAddress = new Uri(options.BaseUrl);
    client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
})
.AddHttpMessageHandler<ApiAuthHandler>();


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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");


app.Run();
