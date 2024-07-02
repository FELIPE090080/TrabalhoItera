using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Trabalho.API.Repositorio;
public class LoteClienteConfiguracoes : IEntityTypeConfiguration<LoteCliente>
{
    public void Configure(EntityTypeBuilder<LoteCliente> builder)
    {
        builder.ToTable("LoteCliente").HasKey(loteCliente => loteCliente.Id);

        builder.Property(nameof(LoteCliente.Id)).HasColumnName("LoteClienteID").IsRequired(); 

        builder.HasOne(loteCliente => loteCliente.Cliente)
                .WithMany(cliente => cliente.LoteClientes)
                .HasForeignKey(loteCliente => loteCliente.Id);

        builder.HasOne(loteCliente => loteCliente.Lote)
                .WithMany(lote => lote.LoteClientes)
                .HasForeignKey(loteCliente => loteCliente.LoteId);
        
    }
}