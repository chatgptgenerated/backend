using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_HelpedProfileId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_HelpingProfileId",
                table: "Follows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follows",
                table: "Follows");

            migrationBuilder.RenameTable(
                name: "Follows",
                newName: "AidRelationships");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_HelpingProfileId",
                table: "AidRelationships",
                newName: "IX_AidRelationships_HelpingProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_HelpedProfileId",
                table: "AidRelationships",
                newName: "IX_AidRelationships_HelpedProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AidRelationships",
                table: "AidRelationships",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AidRelationships_AspNetUsers_HelpedProfileId",
                table: "AidRelationships",
                column: "HelpedProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AidRelationships_AspNetUsers_HelpingProfileId",
                table: "AidRelationships",
                column: "HelpingProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AidRelationships_AspNetUsers_HelpedProfileId",
                table: "AidRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_AidRelationships_AspNetUsers_HelpingProfileId",
                table: "AidRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AidRelationships",
                table: "AidRelationships");

            migrationBuilder.RenameTable(
                name: "AidRelationships",
                newName: "Follows");

            migrationBuilder.RenameIndex(
                name: "IX_AidRelationships_HelpingProfileId",
                table: "Follows",
                newName: "IX_Follows_HelpingProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_AidRelationships_HelpedProfileId",
                table: "Follows",
                newName: "IX_Follows_HelpedProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follows",
                table: "Follows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_HelpedProfileId",
                table: "Follows",
                column: "HelpedProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_HelpingProfileId",
                table: "Follows",
                column: "HelpingProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
