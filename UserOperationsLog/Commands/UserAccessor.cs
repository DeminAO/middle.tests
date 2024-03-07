namespace UserOperationsLog.Commands;

internal class UserAccessor
{
	public Guid UserId { get; }
    public UserAccessor()
    {
		// init by IHttpContextAccessor
		UserId = Guid.NewGuid();
    }
}
