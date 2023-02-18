namespace Application.Common.Exceptions;
public class DatabaseException : Exception
{
	public DatabaseException(int id) : base($"Couldn't fetch resource with given id: {id}")
	{
	}
}
