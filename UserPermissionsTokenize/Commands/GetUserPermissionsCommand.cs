
using UserPermissionsTokenize.Domain;

namespace UserPermissionsTokenize.Commands;

/// <summary>
/// Модель информации о пользователе
/// </summary>
/// <param name="UserId">Идентификатор пользователя</param>
/// <param name="Permissions">Список разрешений пользователя</param>
public record TokenModel(Guid UserId, string[] Permissions)
{
	/// <summary>
	/// Осуществляет проверку наличия указанного разрешения у пользователя
	/// </summary>
	/// <param name="permissionName">Наименование разрешения из констант <see cref="Domain.Constants.PermissionsNames"/></param>
	/// <returns>Истина если пользователь имеет указанное разрешение, иначе - ложь</returns>
	public bool HasPermission(string permissionName)
	{
		return Permissions.Contains(permissionName);
	}
}

internal class GetUserPermissionsCommand(TestDatabase context)
{
	/// <summary>
	/// Осуществляет сбор данных о пльзователе
	/// </summary>
	/// <param name="userId">идентификатор пользователя</param>
	/// <returns></returns>
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
