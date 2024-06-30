using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trabalho.API.Trabalho.Dominio;

namespace Trabalho.API.Repositorio;
public class ClienteConfiguracoes : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente").HasKey(cliente => cliente.Id);

        builder.Property(nameof(Cliente.Id)).HasColumnName("ClienteID").IsRequired();  
        builder.Property(nameof(Cliente.Nome)).HasColumnName("Nome").HasMaxLength(256).IsRequired();
        builder.Property(nameof(Cliente.Email)).HasColumnName("Email").HasMaxLength(256).IsRequired();
        builder.Property(nameof(Cliente.Senha)).HasColumnName("Senha").HasMaxLength(256).IsRequired();
        builder.Property(nameof(Cliente.Ativo)).HasColumnName("Ativo");

        
    }
}