using Shared.TodoTasks.Commands;

namespace Shared.ViewModels.Queries.GetTodoTask;

public class GetTodoTaskDto : IMapFrom<TodoTask>
{
	public GetTodoTaskDto()
	{
		Title = string.Empty;
	}
	public int? Id { get; set; }
	public string? Title { get; set; }
	public DateTime? Deadline { get; set; }
	public bool? Completed { get; set; }
	public int? PriorityId { get; set; }
	public int? TodoListId { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<TodoTask, GetTodoTaskDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
		profile.CreateMap<GetTodoTaskDto, CreateTodoTaskCommand>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
		profile.CreateMap<GetTodoTaskDto, UpdateTodoTaskCommand>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
