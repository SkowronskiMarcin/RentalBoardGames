using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RentalBoardGames.Entities.ViewModels;

namespace RentalBoardGames.Entities
{
    public class MyBoardsContext : DbContext
    {
        public MyBoardsContext(DbContextOptions<MyBoardsContext> options) : base(options)
        {

        }
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BoardGameComment> BoardGameComments { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        //Widoki
        public DbSet<TopAuthor> ViewTopAuthors {get;set;} 
        public DbSet<MostComment> ViewMostComments { get;set;} 
        public DbSet<NotAvailableGame> ViewNotAvailableGames { get;set;} 
        public DbSet<TagGame> ViewTagGames { get;set;} 
        public DbSet<UserAdress> ViewUsersAdress{ get;set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardGame>(ef =>
            {
                ef.HasMany(w => w.Comments) // Relacja 1 : * z BoardGameComment
                .WithOne(c => c.BoardGame)
                .HasForeignKey(d => d.BoardGameId);

                ef.HasMany(w => w.Transactions) // Relacja 1 : * z Transaction
               .WithOne(c => c.BoardGame)
               .HasForeignKey(d => d.BoardGameId);

                ef.HasMany(w => w.Tags) // Relacja * : * z Tag
                .WithMany(t => t.BoardGames);
            });

            modelBuilder.Entity<BoardGameComment>(ed =>
            {
                ed.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()"); //Ustawia automatycznie datę teraźniejszą
                ed.Property(x => x.UpdatedDate).ValueGeneratedOnUpdate(); //Ustawia automatycznie datę przy edycji

            });

            modelBuilder.Entity<User>(ec =>
            {
                ec.Property(x => x.UserType).HasDefaultValue(1); //Domyślnie ustawia typ użytkownika 1

                ec.HasOne(u => u.Adress) //Relacja 1:1 z Adressem
                .WithOne(u => u.User)
                .HasForeignKey<Adress>(a => a.UserId);

                

                ec.HasMany(w => w.Comments) // Relacja 1 : * z BoardGameComment
               .WithOne(c => c.User)
               .HasForeignKey(d => d.UserId);

                ec.HasMany(w => w.Transactions) // Relacja 1 : * z Transaction
                .WithOne(c => c.User)
                .HasForeignKey(d => d.UserId);

            });

            modelBuilder.Entity<BoardGame>() //Początkowe dane
                .HasData
                (new BoardGame() {Name="Brzdek nie draznij smoka",Number_of_players=4, Id=1 },
                new BoardGame() { Name="Everdell", Number_of_players = 4, Id = 2 },
                new BoardGame() { Name = "Nemesis", Number_of_players = 5, Id = 3 });

            modelBuilder.Entity<Tag>()
                .HasData(
                new Tag() { Value = "Horror", Id = 1 }, 
                new Tag() { Value = "Fantasy", Id = 2 }, 
                new Tag() { Value = "Semi-coop", Id = 3 }, 
                new Tag() { Value = "Euro", Id = 4 });

            modelBuilder.Entity<User>()
                .HasData(
                new User() { Id=1, Email="dsds@wp.pl", FirstName="Marcin", LastName="Skowroński"},
                new User() { Id = 2, Email = "mateusz@wp.pl", FirstName = "Mateusz", LastName = "Polak" },
                new User() { Id = 3, Email = "Kamil@wp.pl", FirstName = "Kamil", LastName = "Chmielewski" }
                );
            modelBuilder.Entity<Adress>()
                .HasData(
                new Adress() { Id=1, UserId=1, City="Jabłonna"},
                new Adress() { Id=2, UserId=2, City="Pruszków"},
                new Adress() { Id=3, UserId=3, City="Warszawa"}
                );
            //Widoki
            modelBuilder.Entity<TopAuthor>(eb => 
            {
                eb.ToView("View_TopAuthors");
                eb.HasNoKey();
            });
            modelBuilder.Entity<MostComment>(eb =>
            {
                eb.ToView("View_MostComments");
                eb.HasNoKey();
            });
            modelBuilder.Entity<NotAvailableGame>(eb =>
            {
                eb.ToView("View_NotAvailableGames");
                eb.HasNoKey();
            });
            modelBuilder.Entity<TagGame>(eb =>
            {
                eb.ToView("View_TagGames");
                eb.HasNoKey();
            });
            modelBuilder.Entity<UserAdress>(eb =>
            {
                eb.ToView("View_UsersAdres");
                eb.HasNoKey();
            });




        }
    }
}
