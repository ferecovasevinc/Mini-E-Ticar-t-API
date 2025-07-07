using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_E_Ticarət_API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                newName: "RefreshTokenExpireDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpireDate",
                table: "AspNetUsers",
                newName: "RefreshTokenExpiryTime");
        }
    }
}
