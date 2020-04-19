using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSFIEF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieStudio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilmStudioName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStudio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    AmountOfMovies = table.Column<int>(nullable: false),
                    IsRented = table.Column<bool>(nullable: false),
                    MovieStudioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_MovieStudio_MovieStudioId",
                        column: x => x.MovieStudioId,
                        principalTable: "MovieStudio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    MoviesId = table.Column<int>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lables_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentedMovies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieStudioId = table.Column<int>(nullable: false),
                    MoviesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentedMovies_MovieStudio_MovieStudioId",
                        column: x => x.MovieStudioId,
                        principalTable: "MovieStudio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentedMovies_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Grade = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    MoviesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieStudioHandeler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieStudioId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    ReviewId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStudioHandeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieStudioHandeler_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieStudioHandeler_MovieStudio_MovieStudioId",
                        column: x => x.MovieStudioId,
                        principalTable: "MovieStudio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieStudioHandeler_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lables_MoviesId",
                table: "lables",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieStudioId",
                table: "Movies",
                column: "MovieStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStudioHandeler_MovieId",
                table: "MovieStudioHandeler",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStudioHandeler_MovieStudioId",
                table: "MovieStudioHandeler",
                column: "MovieStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStudioHandeler_ReviewId",
                table: "MovieStudioHandeler",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedMovies_MovieStudioId",
                table: "RentedMovies",
                column: "MovieStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedMovies_MoviesId",
                table: "RentedMovies",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MoviesId",
                table: "Reviews",
                column: "MoviesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lables");

            migrationBuilder.DropTable(
                name: "MovieStudioHandeler");

            migrationBuilder.DropTable(
                name: "RentedMovies");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "MovieStudio");
        }
    }
}
