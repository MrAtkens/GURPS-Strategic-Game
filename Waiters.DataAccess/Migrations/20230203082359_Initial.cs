using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefaultTemplate.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "portal");

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "portal",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<string>(type: "text", nullable: true),
                    Name_Kk = table.Column<string>(type: "text", nullable: true),
                    Name_En = table.Column<string>(type: "text", nullable: true),
                    Name_Ru = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Permissions_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "portal",
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Lat = table.Column<double>(type: "double precision", nullable: false),
                    Lng = table.Column<double>(type: "double precision", nullable: false),
                    UserEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Bin = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreateById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    UserEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CreateById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Name_Kk = table.Column<string>(type: "text", nullable: true),
                    Name_En = table.Column<string>(type: "text", nullable: true),
                    Name_Ru = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles_Permmissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<string>(type: "text", nullable: false),
                    PermissionEntityId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles_Permmissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_Roles_Permmissions_Permissions_PermissionEntityId",
                        column: x => x.PermissionEntityId,
                        principalSchema: "portal",
                        principalTable: "Permissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roles_Permmissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "portal",
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roles_Permmissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "portal",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginMail = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Name_Kk = table.Column<string>(type: "text", nullable: true),
                    Name_En = table.Column<string>(type: "text", nullable: true),
                    Name_Ru = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "portal",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreateById",
                        column: x => x.CreateById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Waiters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    CreateById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waiters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waiters_Users_CreateById",
                        column: x => x.CreateById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Waiters_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Waiters_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Waiters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_CreateById",
                table: "AddressDetails",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_DeletedById",
                table: "AddressDetails",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_ModifiedById",
                table: "AddressDetails",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_UserEntityId",
                table: "AddressDetails",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_UserId",
                table: "AddressDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_CreateById",
                table: "Businesses",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_DeletedById",
                table: "Businesses",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_ModifiedById",
                table: "Businesses",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_UserId",
                table: "Businesses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_CreateById",
                table: "ContactDetails",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_DeletedById",
                table: "ContactDetails",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ModifiedById",
                table: "ContactDetails",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_UserEntityId",
                table: "ContactDetails",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_UserId",
                table: "ContactDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreateById",
                table: "Employees",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeletedById",
                table: "Employees",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ModifiedById",
                table: "Employees",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentId",
                schema: "portal",
                table: "Permissions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreateById",
                schema: "portal",
                table: "Roles",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DeletedById",
                schema: "portal",
                table: "Roles",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ModifiedById",
                schema: "portal",
                table: "Roles",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Permmissions_PermissionEntityId",
                table: "Roles_Permmissions",
                column: "PermissionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Permmissions_PermissionId",
                table: "Roles_Permmissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreateById",
                table: "Users",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedById",
                table: "Users",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoginMail",
                table: "Users",
                column: "LoginMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedById",
                table: "Users",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Waiters_CreateById",
                table: "Waiters",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Waiters_DeletedById",
                table: "Waiters",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Waiters_ModifiedById",
                table: "Waiters",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Waiters_UserId",
                table: "Waiters",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDetails_Users_CreateById",
                table: "AddressDetails",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDetails_Users_DeletedById",
                table: "AddressDetails",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDetails_Users_ModifiedById",
                table: "AddressDetails",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDetails_Users_UserEntityId",
                table: "AddressDetails",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDetails_Users_UserId",
                table: "AddressDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Users_CreateById",
                table: "Businesses",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Users_DeletedById",
                table: "Businesses",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Users_ModifiedById",
                table: "Businesses",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Users_UserId",
                table: "Businesses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Users_CreateById",
                table: "ContactDetails",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Users_DeletedById",
                table: "ContactDetails",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Users_ModifiedById",
                table: "ContactDetails",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Users_UserEntityId",
                table: "ContactDetails",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Users_UserId",
                table: "ContactDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_CreateById",
                table: "Employees",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_DeletedById",
                table: "Employees",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_ModifiedById",
                table: "Employees",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreateById",
                schema: "portal",
                table: "Roles",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_DeletedById",
                schema: "portal",
                table: "Roles",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_ModifiedById",
                schema: "portal",
                table: "Roles",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_CreateById",
                schema: "portal",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_DeletedById",
                schema: "portal",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_ModifiedById",
                schema: "portal",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "AddressDetails");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Roles_Permmissions");

            migrationBuilder.DropTable(
                name: "Waiters");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "portal");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "portal");
        }
    }
}
