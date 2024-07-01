using Microsoft.EntityFrameworkCore;
using Trabalho.API.Repositorio;

public class TrabalhoContexto : DbContext
{
    private readonly DbContextOptions _options;
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Lote> Lotes { get; set; }
    public DbSet<Administrador> Administradores { get; set; }

    public TrabalhoContexto(DbContextOptions<TrabalhoContexto> options) : base(options)
    {
        _options = options;
    }

    public TrabalhoContexto() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=NitroFelipe\\SQLEXPRESS;Database=TrabalhoItera360;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteConfiguracoes());
        modelBuilder.ApplyConfiguration(new LoteConfiguracoes());
        modelBuilder.ApplyConfiguration(new AdministradorConfiguracoes());
    }
}