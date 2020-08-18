using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class MunicipioMap : IEntityTypeConfiguration<MunicipioEntity>
    {
        public void Configure(EntityTypeBuilder<MunicipioEntity> builder)
        {
            builder.ToTable("Municipio");

            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Uf)
                   .WithMany(m => m.Municipios);

            builder.Property(m => m.Cidade)
                   .IsRequired()
                   .HasMaxLength(40);
        }
    }
}
