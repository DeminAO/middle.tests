
using UserPermissionsTokenize.Domain;

namespace UserPermissionsTokenize.Commands;

/*
	2. каждый апи-метод перед выполнением проверяет наличие у пользователя разрешения. 
	Если разрешения нет, то выполнение обработчика завершается с ошибкой. 
	Каждая такая проверка подразумевает получение списка разрешений пользователя по назначенным ему ролям: 
		пользователь -> список ролей -> список разрешений -> получение наименований разрешений
	Чтобы сократить количество обращений к бд, было решено делать запрос разрешений один раз – при входе в систему
	и сохранять их в access-токен

	Необходимо сократить объем данных, хранимых в токене

	пример данных:
		user 1: role 1, role 2
		user 2: role 2, role 3, role 4
		user 3: role 4
		
		role 1: 50 permissions
		role 2: 65 permissions
		role 3: 45 permissions
		role 4: 85 permissions
	
	общее количество разрешений: 100
	ср. длина наименования разрешения: 15 символов
	макс. длина наименования разрешения: 50 символов
*/


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
