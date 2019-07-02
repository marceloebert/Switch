using Microsoft.EntityFrameworkCore;
using Switch.Domain.Entities;
using Switch.Infra.Data.Config;

namespace Switch.Infra.Data.Context
{
    public class SwitchContext : DbContext
    {
        internal DbSet<Usuario> Usuarios { get; set; }
        internal DbSet<Postagem> Postagens { get; set; }
        internal DbSet<StatusRelacionamento> StatusRelacionamento { get; set; }

        public SwitchContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PostagemConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
