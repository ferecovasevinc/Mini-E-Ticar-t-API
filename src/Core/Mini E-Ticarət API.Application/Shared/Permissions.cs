using Microsoft.AspNetCore.Http.HttpResults;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Mini_E_Ticarət_API.Application.Shared;

public static class Permissions
{
    public static class Category
    {
        public const string Create = "Category.Create";
        public const string Update = "Category.Update";
        public const string Delete = "Category.Delete";

        public static List<string> All = new()
        {
            Create,
            Update,
            Delete
        };
    }

    public static class Role
    {
        public const string GetAllPermissions = "Role.GetAllPermissions";
        public const string Create = "Role.Create";

        public static List<string> All = new()
        {
            GetAllPermissions,
            Create
        };
    }

    public static class Account
    {
        public const string AddRole = "Account.AddRole";

        public static List<string> All = new()
        {
            AddRole
        };
    }
}
