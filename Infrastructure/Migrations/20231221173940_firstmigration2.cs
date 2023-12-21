using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class firstmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MENSAGEM_AspNetUsers_UserId",
                table: "TB_MENSAGEM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_MENSAGEM",
                table: "TB_MENSAGEM");

            migrationBuilder.RenameTable(
                name: "TB_MENSAGEM",
                newName: "TB_MESSAGE");

            migrationBuilder.RenameColumn(
                name: "MSG_TITULO",
                table: "TB_MESSAGE",
                newName: "MSN_TITULO");

            migrationBuilder.RenameColumn(
                name: "MSG_DATA_CADASTRO",
                table: "TB_MESSAGE",
                newName: "MSN_DATA_CADASTRO");

            migrationBuilder.RenameColumn(
                name: "MSG_DATA_ALTERACAO",
                table: "TB_MESSAGE",
                newName: "MSN_DATA_ALTERACAO");

            migrationBuilder.RenameColumn(
                name: "MSG_ATIVO",
                table: "TB_MESSAGE",
                newName: "MSN_ATIVO");

            migrationBuilder.RenameColumn(
                name: "MSG_ID",
                table: "TB_MESSAGE",
                newName: "MSN_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TB_MENSAGEM_UserId",
                table: "TB_MESSAGE",
                newName: "IX_TB_MESSAGE_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_MESSAGE",
                table: "TB_MESSAGE",
                column: "MSN_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MESSAGE_AspNetUsers_UserId",
                table: "TB_MESSAGE",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_MESSAGE_AspNetUsers_UserId",
                table: "TB_MESSAGE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_MESSAGE",
                table: "TB_MESSAGE");

            migrationBuilder.RenameTable(
                name: "TB_MESSAGE",
                newName: "TB_MENSAGEM");

            migrationBuilder.RenameColumn(
                name: "MSN_TITULO",
                table: "TB_MENSAGEM",
                newName: "MSG_TITULO");

            migrationBuilder.RenameColumn(
                name: "MSN_DATA_CADASTRO",
                table: "TB_MENSAGEM",
                newName: "MSG_DATA_CADASTRO");

            migrationBuilder.RenameColumn(
                name: "MSN_DATA_ALTERACAO",
                table: "TB_MENSAGEM",
                newName: "MSG_DATA_ALTERACAO");

            migrationBuilder.RenameColumn(
                name: "MSN_ATIVO",
                table: "TB_MENSAGEM",
                newName: "MSG_ATIVO");

            migrationBuilder.RenameColumn(
                name: "MSN_ID",
                table: "TB_MENSAGEM",
                newName: "MSG_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TB_MESSAGE_UserId",
                table: "TB_MENSAGEM",
                newName: "IX_TB_MENSAGEM_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_MENSAGEM",
                table: "TB_MENSAGEM",
                column: "MSG_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_MENSAGEM_AspNetUsers_UserId",
                table: "TB_MENSAGEM",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
