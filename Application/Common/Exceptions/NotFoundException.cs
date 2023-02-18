namespace Application.Common.Exceptions;
public class NotFoundException : Exception
{
	public NotFoundException(int id) : base($"Couldn't find resource with given id: {id}")
	{
	}
}
