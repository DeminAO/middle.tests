using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants;

public class PermissionsNames
{
	public const string GetUsers = nameof(GetUsers);
	public const string DeleteUser = nameof(DeleteUser);
	public const string UpsertUser = nameof(UpsertUser);
	public const string GetUserPhone = nameof(GetUserPhone);
}
