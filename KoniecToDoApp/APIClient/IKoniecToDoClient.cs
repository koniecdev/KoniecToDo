using Shared.TodoLists.Commands;
using Shared.TodoTasks.Commands;
using Shared.ViewModels.Queries.GetHome;
using Shared.ViewModels.Queries.GetTodoList;
using Shared.ViewModels.Queries.GetTodoTask;
namespace KoniecToDoApp.APIClient;

public interface IKoniecToDoClient
{
    Task<GetHomeVm> GetHome();
    Task<GetHomeVm> GetHome(int selectedTodoListId);

    Task<GetTodoTaskVm> GetTodoTask();
    Task<GetTodoTaskVm> GetTodoTask(int selectedTodoTaskId);

    Task<GetTodoListVm> GetTodoList();
    Task<GetTodoListVm> GetTodoList(int selectedTodoListId);

    Task<int> CreateTodoTask(CreateTodoTaskCommand command);
    Task UpdateTodoTask(UpdateTodoTaskCommand command);
    Task DeleteTodoTask(int id);

    Task<int> CreateTodoList(CreateTodoListCommand command);
    Task UpdateTodoList(UpdateTodoTaskCommand command);
    Task DeleteTodoList(int id);

}
