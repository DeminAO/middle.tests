namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = [];
}

public class UserRole
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }
}

public class Role
{
    public Guid Id { get; set; }

	public ICollection<UserRole> UserRoles { get; set; } = [];
	public ICollection<RolePermission> RolePermissions { get; set; } = [];

}

public class RolePermission
{
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }

    public Guid PermissionId { get; set; }
    public virtual Permission Permission { get; set; }
}

public class Permission
{
	public Guid Id { get; set; }
	public string Name { get; set; }

	public ICollection<RolePermission> RolePermissions { get; set; } = [];
}