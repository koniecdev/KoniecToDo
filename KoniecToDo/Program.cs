using Application;
using Infrastructure;
using Persistance;
using Serilog;
using Shared;

WebApplicationBuilder? builder = null;
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
try
{
	Log.Information("Application is starting up");
	builder = WebApplication.CreateBuilder(args);
}
catch (Exception ex)
{
	Log.Fatal(ex, "Could not start up application");
}
finally
{
	Log.CloseAndFlush();
}
if(builder == null)
{
	try
	{
		Log.Fatal("builder is null");
		throw new Exception();
	}
	finally
	{
		Log.CloseAndFlush();
	}
}
builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
	options.AddPolicy("MyOrigins", policy =>
	{
		policy.WithOrigins("https://localhost:7294").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
	});
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddShared();
builder.Services.AddApplication();
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseRouting();
app.UseCors("MyOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseEndpoints(endpoints =>
{
	endpoints.MapHub<NotificationHub>("/notification-hub");
});

app.Run();
