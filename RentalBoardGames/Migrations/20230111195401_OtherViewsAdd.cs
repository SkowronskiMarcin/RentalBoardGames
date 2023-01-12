using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalBoardGames.Migrations
{
    
    public partial class OtherViewsAdd : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW View_MostComments AS
                SELECT u.Id,u.Name, COUNT(*) as [Comments]
	            FROM BoardGames u
                Join BoardGameComments wi on wi.UserId = u.Id
	            GROUP BY u.Id,u.Name
                           ");
            migrationBuilder.Sql(@"
                CREATE VIEW View_NotAvailableGames AS
                SELECT u.Id,u.Name, wi.Deadline, CONCAT(wu.FirstName,' ',wu.LastName) AS [FullName]
	            FROM BoardGames u	
	            Join Transactions wi on wi.BoardGameId = u.Id
	            Join Users wu on wu.Id = wi.UserId
	            Where u.availability = 0
	            GROUP BY u.Id,u.Name,wi.Deadline,wu.FirstName,wu.LastName
                           ");
            migrationBuilder.Sql(@"
                CREATE VIEW View_TagGames AS
                SELECT u.Value, bg.Name
	            FROM Tags u
	            Join BoardGameTag hu on hu.TagsId = u.Id
	            Join BoardGames bg on bg.Id = hu.BoardGamesId
	            Group by u.Value, bg.Name	
                           ");
            migrationBuilder.Sql(@"
                CREATE VIEW View_UsersAdres AS
                SELECT u.Id,Concat(u.FirstName,' ',u.LastName)as [FullName],CONCAT(a.Street,' ',a.PostalCode,' ',a.City) as [Adress]
	            FROM Users u
	            Join Adresses a on a.UserId = u.Id
                           ");
        }
     
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP VIEW View_MostComments
                           ");
            migrationBuilder.Sql(@"
                DROP VIEW View_NotAvailableGames
                           ");
            migrationBuilder.Sql(@"
                DROP VIEW View_TagGames
                           ");
            migrationBuilder.Sql(@"
                DROP VIEW View_UsersAdres
                           ");

        }
    }
}
