namespace Domain.Constants;

/// <summary>
/// Разрешения пользователей <br/>
/// Являются константами выполнения, <br/>
/// список изменяется только при реализации какой-либо фичи
/// </summary>
public class PermissionsNames
{
	/// <summary>
	/// Просмотр отчетов
	/// </summary>
	public const string ExportReport = nameof(ExportReport);
	/// <summary>
	/// Удаление карточки пользователя
	/// </summary>
	public const string DeleteUser = nameof(DeleteUser);
	/// <summary>
	/// Создание, изменение данных в карточке пользователя
	/// </summary>
	public const string UpsertUser = nameof(UpsertUser);
	/// <summary>
	/// Отображение телефона пользователя
	/// </summary>
	public const string GetUserPhone = nameof(GetUserPhone);
	/// <summary>
	/// Оплата счетов
	/// </summary>
	public const string PayBill = nameof(PayBill);
}
