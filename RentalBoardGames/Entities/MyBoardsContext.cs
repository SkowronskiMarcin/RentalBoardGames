using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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

                ec.HasMany(w => w.Rented_Games) // Relacja 1 : * z BoardGame
                .WithOne(c => c.User)
                .HasForeignKey(d => d.UserId);

                ec.HasMany(w => w.Comments) // Relacja 1 : * z BoardGameComment
               .WithOne(c => c.User)
               .HasForeignKey(d => d.UserId);

                ec.HasMany(w => w.Transactions) // Relacja 1 : * z Transaction
                .WithOne(c => c.User)
                .HasForeignKey(d => d.UserId);

            });

            modelBuilder.Entity<Adress>(eb =>
            {
                eb.Property(x => x.Coutry).HasDefaultValueSql("Poland"); //Domyślnie ustawia Polskę

            });

            


        }
    }
}
