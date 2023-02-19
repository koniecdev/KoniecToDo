using Shared.Priorities.Commands;
using Shared.Priorities.Queries.GetAll;

namespace KoniecToDo.Controllers;

[Route("api/priorities")]
public class PriorityController : BaseController
{
	[HttpGet]
	public async Task<ActionResult<GetPrioritiesVm>> GetAll()
	{
		var response = await Mediator.Send(new GetPrioritiesQuery());
		if(response is null)
		{
			return NotFound();
		}
		return Ok(response);
	}

	[HttpPost]
	public async Task<ActionResult<int>> Create(CreatePriorityCommand command)
	{
		if(command is null)
		{
			return BadRequest("Command can not be null");
		}
		try
		{
			int response = await Mediator.Send(command);
			if (response <= 0)
			{
				return BadRequest("Could not add entity to database");
			}
			return Ok(response);
		}
		catch(Exception ex)
		{
			return ValidationProblem(ex.Message);
		}
	}

	[HttpPatch]
	public async Task<ActionResult> Update(UpdatePriorityCommand command)
	{
		if (command is null || command.Id < 1 || command.Id > int.MaxValue)
		{
			return BadRequest("ID must be greater than 0");
		}
		try
		{
			await Mediator.Send(command);
			return NoContent();
		}
		catch (Exception ex)
		{
			return ValidationProblem(ex.Message);
		}
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> Delete(int id)
	{
		if (id < 1 || id > int.MaxValue)
		{
			return BadRequest("ID must be greater than 0");
		}
		try
		{
			await Mediator.Send(new DeletePriorityCommand(id));
			return NoContent();
		}
		catch
		{
			return BadRequest("Could not delete entity");
		}
	}
}