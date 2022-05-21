using Microsoft.EntityFrameworkCore.Migrations;

namespace ReposatoryLayer.Migrations
{
    public partial class Labels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "labels",
                columns: table => new
                {
                    LabelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Userid = table.Column<int>(type: "int", nullable: true),
                    NoteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labels", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_labels_Notes_NoteID",
                        column: x => x.NoteID,
                        principalTable: "Notes",
                        principalColumn: "NoteID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_labels_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "Userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_labels_NoteID",
                table: "labels",
                column: "NoteID");

            migrationBuilder.CreateIndex(
                name: "IX_labels_Userid",
                table: "labels",
                column: "Userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "labels");
        }
    }
}
