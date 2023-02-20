using Shared.ViewModels.Queries.GetHome;
using Shared.ViewModels.Queries.GetTodoTask;
using Shared.ViewModels.Queries.GetTodoList;

namespace KoniecToDo.Controllers;

[Route("api/view-models")]
public class ViewModelsController : BaseController
{

	[HttpGet("home")]
	public async Task<ActionResult<GetHomeVm>> GetHome()
	{
		var response = await Mediator.Send(new GetHomeQuery());
		if(response is null)
		{
			return NotFound();
		}
		return Ok(response);
	}

	[HttpGet("home/{selectedTodoListId}")]
	public async Task<ActionResult<GetHomeVm>> GetHomeWithSelectedTodoList(int selectedTodoListId)
	{
		var response = await Mediator.Send(new GetHomeQuery(selectedTodoListId));
		if (response is null)
		{
			return NotFound();
		}
		return Ok(response);
	}

	[HttpGet("home/Date/{date}")]
	public async Task<ActionResult<GetHomeVm>> GetHome(string date)
	{
		var response = await Mediator.Send(new GetHomeQuery(date));
		if (response is null)
		{
			return NotFound();
		}
		return Ok(response);
	}

	[HttpGet("home/{selectedTodoListId}/Date/{date}")]
	public async Task<ActionResult<GetHomeVm>> GetHomeWithSelectedTodoList(int selectedTodoListId, string date)
	{
		var response = await Mediator.Send(new GetHomeQuery(selectedTodoListId, date));
		if (response is null)
		{
			return NotFound();
		}
		return Ok(response);
	}

	[HttpGet("todo-task")]
	public async Task<ActionResult<GetTodoTaskVm>> GetTodoTask()
	{
		var response = await Mediator.Send(new GetTodoTaskQuery());
		if (response is null)
		{
			return NotFound();
		}
		return Ok(response);
	}

	[HttpGet("todo-task/{todoTaskId}")]
	public async Task<ActionResult<GetTodoTaskVm>> GetTodoTask(int todoTaskId)
	{
		var response = await Mediator.Send(new GetTodoTaskQuery(todoTaskId));
		if (response is null)
		{
			return NotFound();
		}
		return Ok(response);
	}

	[HttpGet("todo-list")]
	public async Task<ActionResult<GetTodoTaskVm>> GetTodoList()
	{
		var response = await Mediator.Send(new GetTodoListQuery());
		if (response is null)
		{
			return NotFound();
		}
		return Ok(response);
	}

	[HttpGet("todo-list/{todoListId}")]
	public async Task<ActionResult<GetTodoTaskVm>> GetTodoList(int todoListId)
	{
		var response = await Mediator.Send(new GetTodoListQuery(todoListId));
		if (response is null)
		{
			return NotFound();
		}
		return Ok(response);
	}
}