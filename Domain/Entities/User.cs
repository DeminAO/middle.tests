namespace Domain.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User
{
    public Guid Id { get; set; }
    /// <summary>
    /// Список ролей пользователя, настраивается пользователями
    /// </summary>
    public ICollection<UserRole> UserRoles { get; set; } = [];
}

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

/// <summary>
/// Роль
/// </summary>
public class Role
{
    public Guid Id { get; set; }
    /// <summary>
    /// Список пользователей, которым назначена роль
    /// </summary>
	public ICollection<UserRole> UserRoles { get; set; } = [];
    /// <summary>
    /// Список разрешений роли, настраивается пользователями
    /// </summary>
	public ICollection<RolePermission> RolePermissions { get; set; } = [];

}

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


/// <summary>
/// Разрешение
/// </summary>
public class Permission
{
	public Guid Id { get; set; }
    /// <summary>
    /// Наименование разрешения. Уникальное, не может меняться во время выполнения
    /// </summary>
	public string Name { get; set; }

    /// <summary>
    /// Список ролей, в которых указано данное разрешение
    /// </summary>
	public ICollection<RolePermission> RolePermissions { get; set; } = [];
}