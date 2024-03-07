namespace UserPermissionsTokenize.Domain.Entities;

/// <summary>
/// Связь роль-разрешение.
/// Одна роль может иметь несколько разрешений, одно разрешение может быть указано в нескольких ролях
/// </summary>
public class RolePermission
{
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }

    public Guid PermissionId { get; set; }
    public virtual Permission Permission { get; set; }
}
