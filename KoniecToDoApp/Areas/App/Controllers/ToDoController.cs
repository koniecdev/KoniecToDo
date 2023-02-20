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
		ViewBag.SelectedDate = stringDate;
		return View(model: await _client.GetHome(stringDate));
	}

	[Route("{selectedTodoListId}/Date/{stringDate}")]
	public async Task<ActionResult> Index(int selectedTodoListId, string stringDate)
	{
		ViewBag.SelectedDate = stringDate;
		return View(model: await _client.GetHome(selectedTodoListId, stringDate));
	}
	[Route("/Completed/{isSelected}")]
	public async Task<ActionResult> Index(bool isSelected)
	{
		ViewBag.Completed = true;
		return View(model: await _client.GetHome(isSelected));
	}

	[Route("{selectedTodoListId}/Completed/{isSelected}")]
	public async Task<ActionResult> Index(int selectedTodoListId, bool isSelected)
	{
		ViewBag.Completed = true;
		return View(model: await _client.GetHome(selectedTodoListId, isSelected));
	}

	[Route("Date/{stringDate}/Completed/{isSelected}")]
	public async Task<ActionResult> Index(string stringDate, bool isSelected)
	{
		ViewBag.SelectedDate = stringDate;
		ViewBag.Completed = true;
		return View(model: await _client.GetHome(stringDate, isSelected));
	}

	[Route("{selectedTodoListId}/Date/{stringDate}/Completed/{isSelected}")]
	public async Task<ActionResult> Index(int selectedTodoListId, string stringDate, bool isSelected)
	{
		ViewBag.SelectedDate = stringDate;
		ViewBag.Completed = true;
		return View(model: await _client.GetHome(selectedTodoListId, stringDate, isSelected));
	}
}
