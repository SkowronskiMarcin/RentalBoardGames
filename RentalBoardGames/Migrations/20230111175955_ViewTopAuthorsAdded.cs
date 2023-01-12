using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalBoardGames.Migrations
{
    /// <inheritdoc />
    public partial class ViewTopAuthorsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW View_TopAuthors AS
                SELECT u.Id,Concat(u.FirstName,' ',u.LastName) as [FullName], COUNT(*) as [CommentsCreated]
                FROM Users u
                Join BoardGameComments wi on wi.UserId = u.Id
                GROUP BY u.Id,u.FirstName,u.LastName            
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP VIEW View_TopAuthors");          
        }
    }
}
