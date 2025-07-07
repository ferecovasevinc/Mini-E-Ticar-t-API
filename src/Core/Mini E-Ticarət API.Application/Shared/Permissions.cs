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

    public static class Favourite
    {
        public const string Create = "Favourite.Create";
        public const string Delete = "Favourite.Delete";
        public const string GetAll = "Favourite.GetAll";

        public static List<string> All = new()
        {
            Create,
            Delete,
            GetAll
        };
    }

    public static class Image
    {
        public const string Upload = "Image.Upload";
        public const string Delete = "Image.Delete";
        public const string GetAll = "Image.GetAll";

        public static List<string> All = new()
        {
            Upload,
            Delete,
            GetAll
        };
    }

    public static class Order
    {
        public const string Create = "Order.Create";
        public const string GetMyOrders = "Order.GetMyOrders";
        public const string GetSales = "Order.GetSales";
        public const string Update = "Order.Update";
        public const string Delete = "Order.Delete";

        public static List<string> All = new()
        {
            Create,
            GetMyOrders,
            GetSales,
            Update,
            Delete
        };
    }

}
