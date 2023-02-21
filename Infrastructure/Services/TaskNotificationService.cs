using Application.Common.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Services;
public class TaskNotificationService : IHostedService, IDisposable
{
    private Timer _timer;
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly IServiceProvider _serviceProvider;
    public TaskNotificationService(IHubContext<NotificationHub> hubContext, IServiceProvider serviceProvider)
    {
        _hubContext = hubContext;
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _timer = new Timer(CheckTasks, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    private async void CheckTasks(object state)
    {
		
        using (var scope = _serviceProvider.CreateScope())
        {
            var _db = scope.ServiceProvider.GetService<IKoniecToDoDbContext>();
            var _dateTime = scope.ServiceProvider.GetService<IDateTime>();
            if (_db != null && _dateTime != null)
			{
                var tasks = _db.TodoTasks.Include(m => m.TodoList)
                .Where(m => m.Deadline <= _dateTime.Now.AddMinutes(2) && m.Deadline > _dateTime.Now && m.TodoList.StatusId != 0 && m.StatusId != 0 && m.Completed != true).ToList();
                foreach (var task in tasks)
                {
                    await _hubContext.Clients.All.SendAsync("ReceiveNotification", $"Task {task.Title} is going to expire in a moment!", $"{task.Id}");
		        }

			}
        }
	}

    public void Dispose()
    {
        _timer?.Dispose();
    }
}