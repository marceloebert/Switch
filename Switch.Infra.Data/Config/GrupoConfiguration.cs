using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Nome)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(g => g.Descricao)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(g => g.UrlFoto)
                   .HasMaxLength(200)
                   .IsRequired();

            //builder.HasMany(g => g.Postagens)
            //       .WithOne

        }
    }
}
