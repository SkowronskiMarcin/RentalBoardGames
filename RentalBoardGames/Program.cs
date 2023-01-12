using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using RentalBoardGames.Entities;
using RentalBoardGames.Entities.ViewModels;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dzieki tej linijce ignorujemy petle
builder.Services.Configure<JsonOptions>(options => 
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

});

builder.Services.AddDbContext<MyBoardsContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyBoardsConnectionString"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Widoki =========================================================================================

// Zwraca Autorów komentarzy i iloœæ ile dodali komentarzy
app.MapGet("View_TopAuthors", (MyBoardsContext db) => 
{
    var topAuthors = db.ViewTopAuthors.ToList();
    return topAuthors;   
});

// Zwraca gry i iloœæ ich komentarzy
app.MapGet("View_MostComments", (MyBoardsContext db) =>
{
    var MostComments = db.ViewMostComments.ToList();
    return MostComments;
});
// Zwraca niedostêpne gry
app.MapGet("View_NotAvailableGames", (MyBoardsContext db) =>
{
    var NotAvailableGames = db.ViewNotAvailableGames.ToList();
    return NotAvailableGames;
});
// Zwraca Tagi i przyporz¹dkowane im gry
app.MapGet("View_TagGames", (MyBoardsContext db) =>
{
    var TagGames = db.ViewTagGames.ToList();
    return TagGames;
});
// Zwraca U¿ytkowników i ich adresy
app.MapGet("View_UsersAdres", (MyBoardsContext db) =>
{
    var UsersAdress = db.ViewUsersAdress.ToList();
    return UsersAdress;
});

//Endpointy =========================================================================================

//Get gry dane tylko z tabeli boardgames
app.MapGet("Games", ( MyBoardsContext db) => 
{  
    var boardGames = db.BoardGames.ToList();
    return boardGames;
});

//Get [z ID] Danej gry + jej tagi + Komentarze
app.MapGet("/GamesCommentsTags/{id}", (int id, MyBoardsContext db) => 
{
    var boardGame = db.BoardGames
    .Include(u => u.Comments)
    .Include(h => h.Tags)
    .First(u => u.Id == id);        
    return boardGame;
});

//Update [Gry o ID] Dostêpnoœæ gry planszowej
app.MapPut("/ChangeAvailability/{id}", (int id, MyBoardsContext db) =>
{
    var boardGame = db.BoardGames.First(u => u.Id == id);
    if (boardGame.availability == true) {
        boardGame.availability = false;
    }
    else{
        boardGame.availability = true;
    }

    db.SaveChanges();
    return boardGame;
});

//Post [] Na dodanie gry planszowej
app.MapPost("/CreateGame/{Name}/{Number_of_players}", (string Name, int Number_of_players, MyBoardsContext db) =>
{
    BoardGame boardGame = new BoardGame()
    {
        Name = Name,
        Number_of_players = Number_of_players,
        availability = true
    };
    db.Add(boardGame);
    db.SaveChanges();
    return boardGame;
});

//Delete[Gry o ID] Gra
app.MapDelete("/DeleteGame/{id}",(int id, MyBoardsContext db) =>
{
    var boardGame = db.BoardGames.First(u => u.Id == id);
    var comments = db.BoardGameComments.Where(u => u.BoardGameId == id).ToList();

    db.RemoveRange(comments);
    db.Remove(boardGame);
    db.SaveChanges();

});

//Delete [Po ID komentarza] Komentarz
app.MapDelete("/DeleteComment/{id}", (int id, MyBoardsContext db) =>
{
    var comment = db.BoardGameComments.First(u => u.Id == id);    
    db.Remove(comment);
    db.SaveChanges();
});

app.Run();

