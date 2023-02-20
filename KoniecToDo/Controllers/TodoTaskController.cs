using Application.Common.Interfaces;
using Shared.TodoTasks.Commands;
using Shared.TodoTasks.Queries.GetAll;

namespace KoniecToDo.Controllers;

[Route("api/todo-tasks")]
public class TodoTaskController : BaseController
{
	private readonly IDateTime _dateTime;
	public TodoTaskController(IDateTime dateTime)
	{
		_dateTime = dateTime;
	}

	[HttpGet]
	public async Task<ActionResult<GetTodoTasksVm>> GetAll()
	{
		var response = await Mediator.Send(new GetTodoTasksQuery());
		if(response is null)
		{
			return NotFound();
		}
		return Ok(response);
	}

	[HttpPost]
	public async Task<ActionResult<int>> Create(CreateTodoTaskCommand command)
	{
		if(command is null)
		{
			return BadRequest("Command can not be null");
		}
		if(command.Deadline < _dateTime.Now)
		{
			return ValidationProblem("Task deadline can not be in past");
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
	public async Task<ActionResult> Update(UpdateTodoTaskCommand command)
	{
		if (command is null || command.Id < 1 || command.Id > int.MaxValue)
		{
			return BadRequest("ID must be greater than 0");
		}
		if(command.Deadline != null)
		{
			if (command.Deadline < _dateTime.Now)
			{
				return ValidationProblem("Task deadline can not be in past");
			}
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
			await Mediator.Send(new DeleteTodoTaskCommand(id));
			return NoContent();
		}
		catch
		{
			return BadRequest("Could not delete entity");
		}
	}
}