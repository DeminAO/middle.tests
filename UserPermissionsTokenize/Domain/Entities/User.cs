namespace UserPermissionsTokenize.Domain.Entities;

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