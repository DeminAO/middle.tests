namespace UserPermissionsTokenize.Domain.Entities;

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
