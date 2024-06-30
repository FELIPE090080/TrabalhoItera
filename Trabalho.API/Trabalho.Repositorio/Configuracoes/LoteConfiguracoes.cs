using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trabalho.API.Trabalho.Dominio;

public class LoteConfiguracoes : IEntityTypeConfiguration<Lote>
{
    public void Configure(EntityTypeBuilder<Lote> builder)
    {
        builder.ToTable("Lote").HasKey(lote => lote.Id);

        builder.Property(nameof(Lote.Id)).HasColumnName("LoteId").IsRequired();
        builder.Property(nameof(Lote.Rua)).HasColumnName("Rua").HasMaxLength(256).IsRequired();
        builder.Property(nameof(Lote.Numero)).HasColumnName("Numero").IsRequired();
        builder.Property(nameof(Lote.Valor)).HasColumnName("Valor").IsRequired();
        builder.Property(nameof(Lote.Tamanho)).HasColumnName("Tamanho").IsRequired();
        builder.Property(nameof(Lote.Disponivel)).HasColumnName("Disponível").IsRequired();

        builder.HasOne(lote => lote.Cliente)
        .WithMany(lote => lote.Lotes)
        .HasForeignKey(lote => lote.ClienteId)
        .OnDelete(DeleteBehavior.Restrict);

    }
}