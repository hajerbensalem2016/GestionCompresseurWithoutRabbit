using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pgh.Auth.Model.Migrations
{
    public partial class tra2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    AppId = table.Column<Guid>(nullable: false),
                    AppCode = table.Column<string>(nullable: true),
                    AppName = table.Column<string>(nullable: true),
                    AppDisplayName = table.Column<string>(nullable: true),
                    AppDescription = table.Column<string>(nullable: true),
                    AppState = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.AppId);
                });

            migrationBuilder.CreateTable(
                name: "Filiale",
                columns: table => new
                {
                    FilialeID = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiale", x => x.FilialeID);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermId = table.Column<Guid>(nullable: false),
                    PermName = table.Column<string>(nullable: true),
                    PermDisplayName = table.Column<string>(nullable: true),
                    PermDescription = table.Column<string>(nullable: true),
                    PermState = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    RoleDisplayName = table.Column<string>(nullable: true),
                    RoleDescription = table.Column<string>(nullable: true),
                    RoleState = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    GrpId = table.Column<Guid>(nullable: false),
                    GrpName = table.Column<string>(nullable: true),
                    GrpDisplayName = table.Column<string>(nullable: true),
                    GrpDescription = table.Column<string>(nullable: true),
                    GrpState = table.Column<bool>(nullable: false),
                    FkAppId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.GrpId);
                    table.ForeignKey(
                        name: "FK_Groupes_Applications",
                        column: x => x.FkAppId,
                        principalTable: "Applications",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    MenuDisplayName = table.Column<string>(nullable: true),
                    MenuDescription = table.Column<string>(nullable: true),
                    MenuUrl = table.Column<string>(nullable: true),
                    MenuState = table.Column<bool>(nullable: false),
                    FkMenuId = table.Column<Guid>(nullable: true),
                    FkAppId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_Applications_FkAppId",
                        column: x => x.FkAppId,
                        principalTable: "Applications",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_FkMenuId",
                        column: x => x.FkMenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UsersId = table.Column<Guid>(nullable: false),
                    UsersCode = table.Column<string>(maxLength: 8, nullable: true),
                    UsersName = table.Column<string>(maxLength: 50, nullable: true),
                    UsersLastName = table.Column<string>(maxLength: 50, nullable: true),
                    UsersState = table.Column<bool>(nullable: false),
                    UsersMail = table.Column<string>(maxLength: 80, nullable: true),
                    UsersMailIntern = table.Column<string>(maxLength: 80, nullable: true),
                    UsersPosteName = table.Column<string>(nullable: true),
                    UsersPhoneNumber = table.Column<string>(nullable: true),
                    UsersPersonalNumber = table.Column<string>(nullable: true),
                    UsersGenderCode = table.Column<string>(nullable: true),
                    UsersBirthDate = table.Column<DateTime>(nullable: false),
                    UsersJoinDate = table.Column<DateTime>(nullable: false),
                    UsersDateLeave = table.Column<DateTime>(nullable: false),
                    FkUsersId = table.Column<Guid>(nullable: true),
                    FilialeID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UsersId);
                    table.ForeignKey(
                        name: "FK_User_Filiale_FilialeID",
                        column: x => x.FilialeID,
                        principalTable: "Filiale",
                        principalColumn: "FilialeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_FkUsersId",
                        column: x => x.FkUsersId,
                        principalTable: "User",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffRolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    PermId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffRolePermissions", x => new { x.PermId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AffRolePermissions_Permissions_PermId",
                        column: x => x.PermId,
                        principalTable: "Permissions",
                        principalColumn: "PermId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffRolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AffRoleGroupMenus",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    GrpId = table.Column<Guid>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffRoleGroupMenus", x => new { x.GrpId, x.MenuId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AffRoleGroupMenus_Groupes_GrpId",
                        column: x => x.GrpId,
                        principalTable: "Groupes",
                        principalColumn: "GrpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffRoleGroupMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffRoleGroupMenus_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AffApplicationUsers",
                columns: table => new
                {
                    AppId = table.Column<Guid>(nullable: false),
                    UsersId = table.Column<Guid>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffApplicationUsers", x => new { x.AppId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AffApplicationUsers_Applications_AppId",
                        column: x => x.AppId,
                        principalTable: "Applications",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffApplicationUsers_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AffGroupUsers",
                columns: table => new
                {
                    UsersId = table.Column<Guid>(nullable: false),
                    GrpId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffGroupUsers", x => new { x.GrpId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AffGroupUsers_Groupes_GrpId",
                        column: x => x.GrpId,
                        principalTable: "Groupes",
                        principalColumn: "GrpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffGroupUsers_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AffRolesUsersMenus",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    UsersId = table.Column<Guid>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffRolesUsersMenus", x => new { x.UsersId, x.MenuId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AffRolesUsersMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffRolesUsersMenus_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffRolesUsersMenus_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "AppId", "AppCode", "AppDescription", "AppDisplayName", "AppName", "AppState" },
                values: new object[,]
                {
                    { new Guid("591315e2-79a9-4714-ad0e-4d497df0d923"), "0000", "Cette application gérer l'authentification et des permissions des différents applications.", "Gestion de l'authentification  des applications", "AuthApp", true },
                    { new Guid("7b71e571-0c91-4af7-aa30-50c773460923"), "0001", "Cette application gérer le processus d'analyse des échantillons par le labo Dick.", "Gestion de laboratoire Dick", "LaboDickAgro", true },
                    { new Guid("98d777f9-5e83-474f-831d-9c3ae0e4d2af"), "0013", "Mise a jour de l'ancienne application Laboratoir Dick.", "Gestion de laboratoire Dick Elevage", "LaboDickElevage", true }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermId", "PermDescription", "PermDisplayName", "PermName", "PermState" },
                values: new object[,]
                {
                    { new Guid("9b644bb6-479d-4bf1-9584-762668d3f200"), "Users Will Have Permission to Manage personal views.", "Manage personal views", "ManagePersonalViews", true },
                    { new Guid("098b55de-e698-4185-8b1c-4a95d8f0be7c"), "Users Will Have Permission to view pages.", "View Pages", "ViewPages", true },
                    { new Guid("db24add3-6e1a-456d-8791-e3c11968eac5"), "Users Will Have Permission to create groups.", "Create Groups", "CreateGroups", true },
                    { new Guid("fe3c0960-b68e-4f30-8177-06c9064924b8"), "Users Will Have Permission to view application pages.", "View application pages", "ViewApplicationPages", true },
                    { new Guid("498be3ca-0653-4ae2-a2f5-eb4f792c3006"), "Users Will Have Permission to Delete versions.", "Delete Versions", "DeleteVersions", true },
                    { new Guid("95805ef3-017a-4aba-932a-963890eff9bb"), "Users Will Have Permission to edit users personal information.", "Edit user's personal information", "EditUserPersonalInformation", true },
                    { new Guid("102f135d-36c8-4f9b-80f5-0c3e6bb44b91"), "Users Will Have Permission to approve items.", "Approve Items", "ApproveItems", true },
                    { new Guid("45f33adf-d105-4e21-821f-2aa2ac82025c"), "Users Will Have Permission to View Items.", "View Items", "ViewItems", true },
                    { new Guid("0236edd4-a0cd-4fba-aa9b-0b8424bdadc2"), "Users Will Have Permission to delete Elements.", "Delete Items", "DeleteItems", true },
                    { new Guid("4e348da5-2e65-4517-9a61-33dc3ae292d6"), "Users Will Have Permission to edit Items.", "Edit Items", "EditItems", true },
                    { new Guid("e76d3e3b-a47a-46d4-aaa8-de1e12cab770"), "Users Will Have the permission to add items", "Add Items", "AddItems", true },
                    { new Guid("979a5449-4ebf-4ed8-8050-8f2ca745d4e6"), "Users Will Have Permission to show versions.", "Show Versions", "ShowVersions", true }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleDescription", "RoleDisplayName", "RoleName", "RoleState" },
                values: new object[,]
                {
                    { new Guid("c78da727-9e7d-452a-ad1b-fc47d9b7234f"), "Restricted reading Default Groupe", "Restricted reading Groupe", "Restricted reading", true },
                    { new Guid("78e84c79-945d-4269-a9af-477992b133eb"), "Approval Default Groupe", "Approval Groupe", "Approval", true },
                    { new Guid("0772297d-3d3f-487f-9cd5-006e54ef3b84"), "Display Only Default Groupe", "Display Only Groupe", "DisplayOnly", true },
                    { new Guid("29ec31cd-814b-4955-bcd5-34529ef3fbe4"), "Limited Access Default Groupe", "Limited Access", "LimitedAccess", true },
                    { new Guid("65b7698a-fe41-4064-8048-c27855149a70"), "Collaboration Default Groupe", "Collaboration Groupe", "Collaboration", true },
                    { new Guid("1bc6aff2-c7c0-4782-884c-9f9aac097915"), "Editors Groupe Default Groupe", "Editors Groupe", "Editors", true },
                    { new Guid("f3bd06fb-0e13-46e4-8705-ee5f75e8f663"), "Design Groupe Default Groupe", "Design Groupe", "Design", true },
                    { new Guid("07a51ed8-b15a-4b9f-b7c6-7f722c29a4bf"), "Total Control Default Groupe", "Total Control", "TotalControl", true },
                    { new Guid("0808054e-1dd2-4525-b781-9efcd7d26e1c"), "Readers Groupe Default Groupe", "Readers Groupe", "Readers", true }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UsersId", "FilialeID", "FkUsersId", "UsersBirthDate", "UsersCode", "UsersDateLeave", "UsersGenderCode", "UsersJoinDate", "UsersLastName", "UsersMail", "UsersMailIntern", "UsersName", "UsersPersonalNumber", "UsersPhoneNumber", "UsersPosteName", "UsersState" },
                values: new object[,]
                {
                    { new Guid("514d33af-f0a1-4a1e-8ab5-6601b1d1b497"), null, null, new DateTime(2019, 10, 8, 15, 8, 36, 349, DateTimeKind.Local).AddTicks(4308), "00000002", new DateTime(2019, 10, 8, 15, 8, 36, 349, DateTimeKind.Local).AddTicks(4309), "M", new DateTime(2019, 10, 8, 15, 8, 36, 349, DateTimeKind.Local).AddTicks(4309), "Test", "User1@poulina.com", "User1@poulina.com", "User1", "63524163", "63524141", "User1 Poste", false },
                    { new Guid("5478e52a-9524-4fb9-a133-4738328ed302"), null, null, new DateTime(2019, 10, 8, 15, 8, 36, 348, DateTimeKind.Local).AddTicks(3321), "00000000", new DateTime(2019, 10, 8, 15, 8, 36, 348, DateTimeKind.Local).AddTicks(9932), "M", new DateTime(2019, 10, 8, 15, 8, 36, 349, DateTimeKind.Local).AddTicks(444), "Admin", "Admin@poulina.com", "Admin@poulina.com", "Admin", "63524163", "63524141", "Admin Poste", false },
                    { new Guid("59c26b29-ad6e-448c-bbc4-6e681e03b0f2"), null, null, new DateTime(2019, 10, 8, 15, 8, 36, 349, DateTimeKind.Local).AddTicks(4275), "00000001", new DateTime(2019, 10, 8, 15, 8, 36, 349, DateTimeKind.Local).AddTicks(4279), "M", new DateTime(2019, 10, 8, 15, 8, 36, 349, DateTimeKind.Local).AddTicks(4283), "SupAdmin", "SupAdmin@poulina.com", "SupAdmin@poulina.com", "SupAdmin", "63524163", "63524141", "SupAdmin Poste", false },
                    { new Guid("3cefac2e-08be-4382-abd4-5793737dac4e"), null, null, new DateTime(2019, 10, 8, 15, 8, 36, 349, DateTimeKind.Local).AddTicks(4312), "00000003", new DateTime(2019, 10, 8, 15, 8, 36, 349, DateTimeKind.Local).AddTicks(4313), "M", new DateTime(2019, 10, 8, 15, 8, 36, 349, DateTimeKind.Local).AddTicks(4313), "Test", "User2@poulina.com", "User2@poulina.com", "User2", "63524163", "63524141", "User2 Poste", false }
                });

            migrationBuilder.InsertData(
                table: "Groupes",
                columns: new[] { "GrpId", "FkAppId", "GrpDescription", "GrpDisplayName", "GrpName", "GrpState" },
                values: new object[,]
                {
                    { new Guid("9254b5f0-58e1-4bce-97e5-b327e13b33a2"), new Guid("591315e2-79a9-4714-ad0e-4d497df0d923"), "Administration Groupe for Authentication Application", "Administration Groupes", "AdministratorAuth", true },
                    { new Guid("c228a803-e516-4d0b-a06e-5997b06038a8"), new Guid("591315e2-79a9-4714-ad0e-4d497df0d923"), "Readers Groupe for Authentication Application", "Readers Groupes", "ReadersAuth", true },
                    { new Guid("8d754963-cf31-47ae-93e5-25252b239497"), new Guid("591315e2-79a9-4714-ad0e-4d497df0d923"), "Editors Groupe for Authentication Application", "Editors Groupes", "EditorsAuth", true }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "FkAppId", "FkMenuId", "MenuDescription", "MenuDisplayName", "MenuName", "MenuState", "MenuUrl" },
                values: new object[,]
                {
                    { new Guid("b3b45342-f596-442c-b0e8-ccc3604a53d5"), new Guid("591315e2-79a9-4714-ad0e-4d497df0d923"), null, "User setup menu.", "Users", "AuthUsers", true, "Http://srvapp/authusers" },
                    { new Guid("f1ede5e9-a959-436a-8cbc-65cc4a7d0ed0"), new Guid("591315e2-79a9-4714-ad0e-4d497df0d923"), null, "Permissions setup menu.", "Permissions", "AuthPermissions", true, "Http://srvapp/authpermissions" },
                    { new Guid("3c9cc54e-9190-4f7a-900f-ed1646cdd89c"), new Guid("591315e2-79a9-4714-ad0e-4d497df0d923"), null, "Roles setup menu.", "Roles", "AuthRoles", true, "Http://srvapp/authroles" },
                    { new Guid("84ed99e3-d844-4bf9-8105-6c938303d6f3"), new Guid("591315e2-79a9-4714-ad0e-4d497df0d923"), null, "Applications setup menu.", "Applications", "AuthApplications", true, "Http://srvapp/authappications" },
                    { new Guid("f9ad0a65-1831-4011-8787-e39ff5bb7b59"), new Guid("591315e2-79a9-4714-ad0e-4d497df0d923"), null, "Menus setup menu.", "Menus", "AuthMenus", true, "Http://srvapp/authmenus" },
                    { new Guid("34db4aae-2418-4668-b836-bc54311f8e8e"), new Guid("591315e2-79a9-4714-ad0e-4d497df0d923"), null, "Groupes setup menu.", "Groupes", "AuthGroupes", true, "Http://srvapp/authgroupes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AffApplicationUsers_UsersId",
                table: "AffApplicationUsers",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AffGroupUsers_UsersId",
                table: "AffGroupUsers",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AffRoleGroupMenus_MenuId",
                table: "AffRoleGroupMenus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AffRoleGroupMenus_RoleId",
                table: "AffRoleGroupMenus",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AffRolePermissions_RoleId",
                table: "AffRolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AffRolesUsersMenus_MenuId",
                table: "AffRolesUsersMenus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AffRolesUsersMenus_RoleId",
                table: "AffRolesUsersMenus",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AppCode",
                table: "Applications",
                column: "AppCode",
                unique: true,
                filter: "([AppCode] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_FkAppId",
                table: "Groupes",
                column: "FkAppId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_FkAppId",
                table: "Menus",
                column: "FkAppId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_FkMenuId",
                table: "Menus",
                column: "FkMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermName",
                table: "Permissions",
                column: "PermName",
                unique: true,
                filter: "([PermName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true,
                filter: "([RoleName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_User_FilialeID",
                table: "User",
                column: "FilialeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_FkUsersId",
                table: "User",
                column: "FkUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UsersCode",
                table: "User",
                column: "UsersCode",
                unique: true,
                filter: "([UsersCode] IS NOT NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AffApplicationUsers");

            migrationBuilder.DropTable(
                name: "AffGroupUsers");

            migrationBuilder.DropTable(
                name: "AffRoleGroupMenus");

            migrationBuilder.DropTable(
                name: "AffRolePermissions");

            migrationBuilder.DropTable(
                name: "AffRolesUsersMenus");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Filiale");
        }
    }
}
