using apimodelo.netcore.domain.domain.Models;
using Microsoft.EntityFrameworkCore;

namespace apimodelo.netcore.infra.Data.MSSQL.Context
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Livros> Livros { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(q =>
            {
                q.ToTable("Usuario").HasKey(x => x.id);
            });

            modelBuilder.Entity<Livros>(q =>
            {
                q.ToTable("Livros").HasKey(x => x.id);
            });
        }
    }
}
