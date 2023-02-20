using AutoMapper;
using KoniecToDoApp.APIClient;
using Microsoft.AspNetCore.Mvc;
using Shared.TodoLists.Commands;
using Shared.ViewModels.Queries.GetTodoList;

namespace KoniecToDoApp.Controllers;

[Area("App")]
public class TodoListController : Controller
{
	private readonly IKoniecToDoClient _client;
	private readonly IMapper _mapper;
	public TodoListController(IKoniecToDoClient client, IMapper mapper)
	{
		_client = client;
		_mapper = mapper;
	}

	[Route("/List/Create")]
	public async Task<ActionResult> Create()
	{
		return View(model: await _client.GetTodoList());
	}

	[HttpPost]
	[Route("/List/Create")]
	public async Task<ActionResult> Create(GetTodoListVm vm)
	{
		CreateTodoListCommand command = _mapper.Map<CreateTodoListCommand>(vm.TodoList);
		var id = await _client.CreateTodoList(command);
		return LocalRedirect($"/{id}");
	}

	[Route("/List/Update/{selectedTodoListId}")]
	public async Task<ActionResult> Update(int selectedTodoListId)
	{
		return View(model: await _client.GetTodoList(selectedTodoListId));
	}

	[HttpPost]
	[Route("/List/Update/{selectedTodoListId}")]
	public async Task<ActionResult> Update(GetTodoListVm vm)
	{
		UpdateTodoListCommand command = _mapper.Map<UpdateTodoListCommand>(vm.TodoList);
		await _client.UpdateTodoList(command);
		return LocalRedirect($"/{command.Id}");
	}

	[Route("/List/Delete/{selectedTodoListId}")]
	public async Task<ActionResult> Delete(int selectedTodoListId)
	{
		await _client.DeleteTodoList(selectedTodoListId);
		return LocalRedirect("/");
	}
}
