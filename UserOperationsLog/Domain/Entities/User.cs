namespace UserOperationsLog.Domain.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; }
}