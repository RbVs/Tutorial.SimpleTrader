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
        public SimpleTraderDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ueberschreibt die Definition und erstellt keine Tabelle "Asset"
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Asset);

            base.OnModelCreating(modelBuilder);
        }
    }
}