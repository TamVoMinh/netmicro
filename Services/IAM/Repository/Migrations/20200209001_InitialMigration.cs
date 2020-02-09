using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nmro.IAM.Reposistory.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up([NotNullAttribute] MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    UserName = table.Column<string>(maxLength: 64, nullable: false),
                    Password = table.Column<string>(maxLength: 1024, nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: false),

                    LastSuccessfulLogin = table.Column<DateTime>(nullable: true),
                    LastFailedLogin = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUsers", x => x.Id);
                }
            );
        }
        protected override void Down(MigrationBuilder migrationBuilder){
            migrationBuilder.DropTable(name: "IdentityUsers");
        }
    }
}
