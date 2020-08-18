using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Cpf)
                    .IsUnique();

            builder.Property(c => c.Cpf)
                   .IsRequired();

            builder.Property(c => c.DataNascimento)
                   .IsRequired();

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(30);
        }
    }
}
