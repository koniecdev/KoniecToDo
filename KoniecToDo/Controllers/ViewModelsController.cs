using Shared.ViewModels.Queries.GetHome;

namespace KoniecToDo.Controllers;

[Route("api/view-models")]
public class ViewModelsController : BaseController
{

	[HttpGet]
	public async Task<ActionResult<GetHomeVm>> GetHome()
	{
		var response = await Mediator.Send(new GetHomeQuery());
		if(response is null)
		{
			return NotFound();
		}
		return Ok(response);
	}

	[HttpGet("{selectedTodoListId}")]
	public async Task<ActionResult<GetHomeVm>> GetHomeWithSelectedTodoList(int selectedTodoListId)
	{
		var response = await Mediator.Send(new GetHomeQuery(selectedTodoListId));
		if (response is null)
		{
			return NotFound();
		}
		return Ok(response);
	}
}