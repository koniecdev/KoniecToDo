using KoniecToDoApp.APIClient;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddHttpClient("KoniecToDoClient", options =>
{
	options.BaseAddress = new Uri(SD.APIUri);
	options.Timeout = new TimeSpan(0, 0, 10000);
	options.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
}).ConfigurePrimaryHttpMessageHandler(sp => new HttpClientHandler());

builder.Services.AddScoped(typeof(IKoniecToDoClient), typeof(KoniecToDoClient));

builder.Services.AddShared();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{area=App}/{controller=ToDo}/{action=Index}/{id?}");

app.Run();
