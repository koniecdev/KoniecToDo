using Microsoft.AspNetCore.Cors;

namespace KoniecToDo.Controllers;

[EnableCors("MyOrigins")]
[ApiController]
public class BaseController : ControllerBase
{
	private IMediator _mediator;
	protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
