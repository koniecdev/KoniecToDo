﻿using Shared.TodoLists.Commands;
using Shared.TodoTasks.Commands;
using Shared.ViewModels.Queries.GetHome;
using Shared.ViewModels.Queries.GetTodoList;
using Shared.ViewModels.Queries.GetTodoTask;
namespace KoniecToDoApp.APIClient;

public interface IKoniecToDoClient
{
    Task<GetHomeVm> GetHome();
    Task<GetHomeVm> GetHome(int selectedTodoListId);
    Task<GetHomeVm> GetHome(string stringDate);
    Task<GetHomeVm> GetHome(int selectedTodoListId, string stringDate);
    Task<GetHomeVm> GetHome(bool completed);
    Task<GetHomeVm> GetHome(int selectedTodoListId, bool completed);
    Task<GetHomeVm> GetHome(string stringDate, bool completed);
    Task<GetHomeVm> GetHome(int selectedTodoListId, string stringDate, bool completed);

    Task<GetTodoTaskVm> GetTodoTask();
    Task<GetTodoTaskVm> GetTodoTask(int selectedTodoTaskId);

    Task<GetTodoListVm> GetTodoList();
    Task<GetTodoListVm> GetTodoList(int selectedTodoListId);

    Task<int> CreateTodoTask(CreateTodoTaskCommand command);
    Task UpdateTodoTask(UpdateTodoTaskCommand command);
    Task DeleteTodoTask(int id);

    Task<int> CreateTodoList(CreateTodoListCommand command);
    Task UpdateTodoList(UpdateTodoListCommand command);
    Task DeleteTodoList(int id);

}
