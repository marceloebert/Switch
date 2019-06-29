using Microsoft.EntityFrameworkCore;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Context
{
    public class SwitchContext : DbContext
    {
        internal DbSet<Usuario> Usuarios { get; set; }

        public SwitchContext(DbContextOptions options) : base(options)
        {

        }
    }
}
