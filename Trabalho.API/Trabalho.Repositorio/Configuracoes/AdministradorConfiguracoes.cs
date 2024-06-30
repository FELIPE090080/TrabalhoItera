using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trabalho.API.Trabalho.Dominio;

namespace Trabalho.API.Repositorio;
public class AdministradorConfiguracoes : IEntityTypeConfiguration<Administrador>
{
    public void Configure(EntityTypeBuilder<Administrador> builder)
    {
        builder.ToTable("Administrador").HasKey(administrador => administrador.Id);

        builder.Property(nameof(Administrador.Id)).HasColumnName("AdministradorId").IsRequired();  
        builder.Property(nameof(Administrador.Nome)).HasColumnName("Nome").HasMaxLength(256).IsRequired();
        builder.Property(nameof(Administrador.Email)).HasColumnName("Email").HasMaxLength(256).IsRequired();
        builder.Property(nameof(Administrador.Senha)).HasColumnName("Senha").HasMaxLength(256).IsRequired();

        
    }
}