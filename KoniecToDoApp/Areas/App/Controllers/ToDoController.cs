using KoniecToDoApp.APIClient;
using Microsoft.AspNetCore.Mvc;

namespace KoniecToDoApp.Controllers;

[Area("App")]
public class ToDoController : Controller
{
	private readonly IKoniecToDoClient _client;
	public ToDoController(IKoniecToDoClient client)
	{
		_client = client;
	}

	public async Task<ActionResult> Index()
	{
		return View(model: await _client.GetHome());
	}

	[Route("{selectedTodoListId}")]
	public async Task<ActionResult> Index(int selectedTodoListId)
	{
		return View(model: await _client.GetHome(selectedTodoListId));
	}

	[Route("Date/{stringDate}")]
	public async Task<ActionResult> Index(string stringDate)
	{
		return View(model: await _client.GetHome(stringDate));
	}

	[Route("{selectedTodoListId}/Date/{stringDate}")]
	public async Task<ActionResult> Index(int selectedTodoListId, string stringDate)
	{
		return View(model: await _client.GetHome(selectedTodoListId, stringDate));
	}
}
