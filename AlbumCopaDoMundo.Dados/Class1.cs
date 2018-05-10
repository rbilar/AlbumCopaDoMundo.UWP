using AlbumCopaDoMundo.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace AlbumCopaDoMundo.Dados
{
    public class AlbumCopaDoMundoDbContext : DbContext
    {
        public DbSet<Figurinha> Figurinhas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AlbumCopaDoMundoDbContext.db");
        }
    }
}