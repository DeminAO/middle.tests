using Domain;

namespace App;

public record TokenModel(Guid UserId, string[] Permissions)
{
	public bool HasPermission(string permissionName)
	{
		return Permissions.Contains(permissionName);
	}
}

internal class GetUserPermissionsCommand(UsersTestDatabase context)
{
	public TokenModel GetUserCredentials(Guid userId)
	{
		var permissionsNames = context.UserRoles
			.Where(x => x.UserId == userId)
			.Select(x => x.Role)
			.SelectMany(x => x.RolePermissions)
			.Select(x => x.Permission)
			.Select(x => x.Name)
			.Distinct()
			.ToArray();
		return new(userId, permissionsNames);
	}
}
