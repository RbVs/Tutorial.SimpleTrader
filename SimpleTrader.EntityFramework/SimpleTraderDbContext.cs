using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;

//ausfuehren einer Migration 
//  PM> add-migration initial
//updated DB 
//  update-database

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ueberschreibt die Definition und erstellt keine Tabelle "Stock"
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Stock);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=SimpleTraderDB;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}