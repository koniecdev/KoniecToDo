using Application.Common.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddScoped<IDateTime, DateTimeService>();
		services.AddSignalR();
		services.AddSingleton<NotificationHub>();
		services.AddSingleton<IHostedService, TaskNotificationService>();
		return services;
	}
}
