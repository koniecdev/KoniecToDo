using AutoMapper;
using KoniecToDoApp.APIClient;
using Microsoft.AspNetCore.Mvc;
using Shared.TodoTasks.Commands;
using Shared.ViewModels.Queries.GetTodoTask;
using System.Globalization;

namespace KoniecToDoApp.Controllers;

[Area("App")]
public class TodoTaskController : Controller
{
	private readonly IKoniecToDoClient _client;
	private readonly IMapper _mapper;
	public TodoTaskController(IKoniecToDoClient client, IMapper mapper)
	{
		_client = client;
		_mapper = mapper;
	}

	[Route("Task/Create")]
	public async Task<ActionResult> Create()
	{
		return View(model: await _client.GetTodoTask());
	}

	[HttpPost]
	[Route("/Task/Create")]
	public async Task<ActionResult> Create(GetTodoTaskVm vm)
	{
		vm.TodoTask.Deadline = DateTime.ParseExact(Request.Form["date"] + " " + Request.Form["time"], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
		CreateTodoTaskCommand command = _mapper.Map<CreateTodoTaskCommand>(vm.TodoTask);
		await _client.CreateTodoTask(command);
		return LocalRedirect($"/{vm.TodoTask.TodoListId}");
	}

	[Route("Task/Update/{selectedTodoTaskId}")]
	public async Task<ActionResult> Update(int selectedTodoTaskId)
	{
		return View(model: await _client.GetTodoTask(selectedTodoTaskId));
	}

	[HttpPost]
	[Route("Task/Update/{selectedTodoTaskId}")]
	public async Task<ActionResult> Update(GetTodoTaskVm vm)
	{
		vm.TodoTask.Deadline = DateTime.ParseExact(Request.Form["date"] + " " + Request.Form["time"], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
		UpdateTodoTaskCommand command = _mapper.Map<UpdateTodoTaskCommand>(vm.TodoTask);
		await _client.UpdateTodoTask(command);
		return LocalRedirect($"/{vm.TodoTask.TodoListId}");
	}

	[Route("Task/Complete/{id}/{isChecked}/{returnListId}")]
	public async Task<ActionResult> Complete(int id, bool isChecked, int returnListId)
	{
		UpdateTodoTaskCommand command = new()
		{
			Id = id,
			Completed = isChecked
		};
		await _client.UpdateTodoTask(command);
		return LocalRedirect("/"+returnListId.ToString());
	}

	[Route("Task/Delete/{id}/{listId}")]
	public async Task<ActionResult> Delete(int id, int listId)
	{
		await _client.DeleteTodoTask(id);
		return LocalRedirect("/" + listId.ToString());
	}
}
