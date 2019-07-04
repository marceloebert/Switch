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
        internal DbSet<Grupo> Grupoo { get; set; }
        internal DbSet<Identificacao> Identificacao { get; set; }
        internal DbSet<UsuarioGrupo> UsuarioGrupo { get; set; }

        public SwitchContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PostagemConfiguration());
            modelBuilder.ApplyConfiguration(new GrupoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioGrupoConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
