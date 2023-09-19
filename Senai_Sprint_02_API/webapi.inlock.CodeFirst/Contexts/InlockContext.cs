using Microsoft.EntityFrameworkCore;
using webapi.inlock.CodeFirst.Domains;

namespace webapi.inlock.CodeFirst.Contexts
{
    public class InlockContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE15-S14; Database=inlock_games_codeFirst_tarde; User Id=sa; Pwd= Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
