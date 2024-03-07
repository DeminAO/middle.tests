namespace UserPermissionsTokenize.Domain.Entities;

/// <summary>
/// Связь пользователь-роль.
/// Один пользователь может иметь несколько ролей, одна роль может быть назначена нескольким пользователям
/// </summary>
public class UserRole
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }
}
