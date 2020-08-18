using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoEntity>
    {
        public void Configure(EntityTypeBuilder<EnderecoEntity> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(u => u.Id);

            builder.Property(e => e.Logradouro)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.Bairro)
                   .IsRequired()
                   .HasMaxLength(40);
        }
    }
}
