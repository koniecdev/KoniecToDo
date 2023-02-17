namespace Domain.Common;
public class AuditableEntity
{
	public int Id { get; set; }
	public int StatusId { get; set; } = 1;
}
