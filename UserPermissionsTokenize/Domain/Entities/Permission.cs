namespace UserPermissionsTokenize.Domain.Entities;

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