global using Newtonsoft.Json;
using Shared.TodoLists.Commands;
using Shared.TodoTasks.Commands;
using Shared.ViewModels.Queries.GetHome;
using Shared.ViewModels.Queries.GetTodoList;
using Shared.ViewModels.Queries.GetTodoTask;
using System.Text;

namespace KoniecToDoApp.APIClient;

public partial class KoniecToDoClient : IKoniecToDoClient
{
	private readonly HttpClient _httpClient;

	private readonly Lazy<JsonSerializerSettings> _settings;
	protected JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

	private string _baseUrl = SD.APIUri;
	public string BaseUrl
	{
		get { return _baseUrl; }
		set { _baseUrl = value; }
	}

	public KoniecToDoClient(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("KoniecToDoClient");
		_baseUrl = _httpClient?.BaseAddress?.ToString()+"api/";
		_settings = new Lazy<JsonSerializerSettings>(() =>
		{
			var settings = new JsonSerializerSettings();
			UpdateJsonSerializerSettings(settings);
			return settings;
		});
	}

	partial void UpdateJsonSerializerSettings(JsonSerializerSettings settings);

	private async Task<T> GetTask<T>(StringBuilder urlBuilder)
	{
		var client = _httpClient;
		using (var request = new HttpRequestMessage())
		{
			request.Method = new HttpMethod("GET");
			var url = urlBuilder.ToString();
			request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
			var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None).ConfigureAwait(false);

			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				if (responseData != null)
				{
					T? model = JsonConvert.DeserializeObject<T>(responseData);
					if(model == null)
					{
						throw new Exception("API returned null response");
					}
					return model;
				}
				throw new Exception("API returned error");
			}
			else
			{
				throw new Exception(response.StatusCode.ToString());
			}
		}
	}

	private async Task<int> CreateTask<T>(T command, string pth)
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append(pth);
		var client = _httpClient;
		using (var request = new HttpRequestMessage())
		{
			request.Method = new HttpMethod("POST");
			var url = urlBuilder.ToString();
			request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
			request.Content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
			var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None).ConfigureAwait(false);

			if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
			{
				var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				if (responseData != null)
				{
					int newId = JsonConvert.DeserializeObject<int>(responseData);
					return newId;
				}
				throw new Exception("API returned error");
			}
			else
			{
				var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				if (responseData != null)
				{
					HttpValidationProblemDetails? validationErrorModel = JsonConvert.DeserializeObject<HttpValidationProblemDetails>(responseData);
					var validationFailedString = $"Error: {validationErrorModel?.Status} - {validationErrorModel?.Detail}";
					throw new Exception(validationFailedString);
				}
				throw new Exception("Something went wrong with retrieving server data");
			}
		}
	}

	private async Task UpdateTask<T>(T command, string pth)
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append(pth);
		var client = _httpClient;
		using (var request = new HttpRequestMessage())
		{
			request.Method = new HttpMethod("PATCH");
			var url = urlBuilder.ToString();
			request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
			request.Content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
			var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None).ConfigureAwait(false);

			if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
			{
				var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				if (responseData != null)
				{
					HttpValidationProblemDetails? validationErrorModel = JsonConvert.DeserializeObject<HttpValidationProblemDetails>(responseData);
					var validationFailedString = $"Error: {validationErrorModel?.Status} - {validationErrorModel?.Detail}";
					throw new Exception(validationFailedString);
				}
				throw new Exception("Something went wrong with retrieving server data");
			}
		}
	}

	private async Task DeleteTask(int idToDelete, string pth)
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append(pth).Append('/').Append(idToDelete);
		var client = _httpClient;
		using (var request = new HttpRequestMessage())
		{
			request.Method = new HttpMethod("DELETE");
			var url = urlBuilder.ToString();
			request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
			var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None).ConfigureAwait(false);

			if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
			{
				var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				if (responseData != null)
				{
					HttpValidationProblemDetails? validationErrorModel = JsonConvert.DeserializeObject<HttpValidationProblemDetails>(responseData);

					throw new Exception($"Error: {validationErrorModel?.Status} - {validationErrorModel?.Detail}");
				}
				throw new Exception("Something went wrong with retrieving server data");
			}
		}
	}

	public async Task<GetHomeVm> GetHome()
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append("view-models/home");
		return await GetTask<GetHomeVm>(urlBuilder);
	}

	public async Task<GetHomeVm> GetHome(int selectedTodoListId)
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append("view-models/home").Append($"/{selectedTodoListId}");
		return await GetTask<GetHomeVm>(urlBuilder);
	}
	public async Task<GetHomeVm> GetHome(string stringDate)
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append("view-models/home/date").Append($"/{stringDate}");
		return await GetTask<GetHomeVm>(urlBuilder);
	}

	public async Task<GetHomeVm> GetHome(int selectedTodoListId, string stringDate)
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append("view-models/home").Append($"/{selectedTodoListId}").Append("/Date").Append($"/{stringDate}");
		return await GetTask<GetHomeVm>(urlBuilder);
	}

	public async Task<GetHomeVm> GetHome(bool completed)
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append("view-models/home/completed/").Append(completed);
		return await GetTask<GetHomeVm>(urlBuilder);
	}

	public async Task<GetHomeVm> GetHome(int selectedTodoListId, bool completed)
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append("view-models/home").Append($"/{selectedTodoListId}").Append("/completed/").Append(completed);
		return await GetTask<GetHomeVm>(urlBuilder);
	}

	public async Task<GetHomeVm> GetHome(string stringDate, bool completed)
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append("view-models/home/date").Append($"/{stringDate}").Append("/completed/").Append(completed); ;
		return await GetTask<GetHomeVm>(urlBuilder);
	}

	public async Task<GetHomeVm> GetHome(int selectedTodoListId, string stringDate, bool completed)
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append("view-models/home").Append($"/{selectedTodoListId}").Append("/Date").Append($"/{stringDate}").Append("/completed/").Append(completed);
		return await GetTask<GetHomeVm>(urlBuilder);
	}

	public async Task<int> CreateTodoTask(CreateTodoTaskCommand command)
	{
		return await CreateTask(command, "todo-tasks");
	}

	public async Task UpdateTodoTask(UpdateTodoTaskCommand command)
	{
		await UpdateTask(command, "todo-tasks");
	}

	public async Task DeleteTodoTask(int id)
	{
		await DeleteTask(id, "todo-tasks");
	}

	public async Task<int> CreateTodoList(CreateTodoListCommand command)
	{
		return await CreateTask(command, "todo-lists");
	}

	public async Task UpdateTodoList(UpdateTodoListCommand command)
	{
		await UpdateTask(command, "todo-lists");
	}

	public async Task DeleteTodoList(int id)
	{
		await DeleteTask(id, "todo-lists");
	}

	public async Task<GetTodoTaskVm> GetTodoTask()
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append("view-models/todo-task");
		return await GetTask<GetTodoTaskVm>(urlBuilder);
	}

	public async Task<GetTodoTaskVm> GetTodoTask(int selectedTodoTaskId)
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append("view-models/todo-task").Append($"/{selectedTodoTaskId}");
		return await GetTask<GetTodoTaskVm>(urlBuilder);
	}

	public async Task<GetTodoListVm> GetTodoList()
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append("view-models/todo-list");
		return await GetTask<GetTodoListVm>(urlBuilder);
	}

	public async Task<GetTodoListVm> GetTodoList(int selectedTodoListId)
	{
		var urlBuilder = new StringBuilder();
		urlBuilder.Append(BaseUrl).Append("view-models/todo-list").Append($"/{selectedTodoListId}");
		return await GetTask<GetTodoListVm>(urlBuilder);
	}
}
