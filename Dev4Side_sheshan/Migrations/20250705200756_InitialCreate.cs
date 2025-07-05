using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev4Side_sheshan.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListEntity_UserEntity_UserId",
                table: "ListEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskEntity_ListEntity_ListId",
                table: "TaskEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskEntity",
                table: "TaskEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListEntity",
                table: "ListEntity");

            migrationBuilder.RenameTable(
                name: "UserEntity",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TaskEntity",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "ListEntity",
                newName: "Lists");

            migrationBuilder.RenameIndex(
                name: "IX_TaskEntity_ListId",
                table: "Tasks",
                newName: "IX_Tasks_ListId");

            migrationBuilder.RenameIndex(
                name: "IX_ListEntity_UserId",
                table: "Lists",
                newName: "IX_Lists_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lists",
                table: "Lists",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_Users_UserId",
                table: "Lists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Lists_ListId",
                table: "Tasks",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "ListId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Users_UserId",
                table: "Lists");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Lists_ListId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lists",
                table: "Lists");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserEntity");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "TaskEntity");

            migrationBuilder.RenameTable(
                name: "Lists",
                newName: "ListEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ListId",
                table: "TaskEntity",
                newName: "IX_TaskEntity_ListId");

            migrationBuilder.RenameIndex(
                name: "IX_Lists_UserId",
                table: "ListEntity",
                newName: "IX_ListEntity_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskEntity",
                table: "TaskEntity",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListEntity",
                table: "ListEntity",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListEntity_UserEntity_UserId",
                table: "ListEntity",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskEntity_ListEntity_ListId",
                table: "TaskEntity",
                column: "ListId",
                principalTable: "ListEntity",
                principalColumn: "ListId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
