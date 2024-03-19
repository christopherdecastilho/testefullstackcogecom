using CogeconAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CogeconAPI.Context
{
    public class dbContext : DbContext
    {
        public DbSet<Cooperado> Cooperados { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<UnidadeConsumidora> UnidadesConsumidoras { get; set; }

        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade Cooperado
            modelBuilder.Entity<Cooperado>()
            .Property(c => c.Nome)
            .HasMaxLength(255)
            .IsRequired();

            modelBuilder.Entity<Cooperado>()
                .Property(c => c.Telefone)
                .HasMaxLength(20);

            modelBuilder.Entity<Cooperado>()
                .Property(c => c.Email)
                .HasMaxLength(255);

            modelBuilder.Entity<Cooperado>()
                .Property(c => c.Ativo)
                .IsRequired();

            // Configuração da entidade Endereco
            modelBuilder.Entity<Endereco>()
                .Property(e => e.Logradouro)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Bairro)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Localidade)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Endereco>()
                .Property(e => e.UF)
                .HasMaxLength(2)
                .IsRequired();

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Numero)
                .HasMaxLength(10);

            // Configuração da entidade UnidadeConsumidora
            modelBuilder.Entity<UnidadeConsumidora>()
                .Property(uc => uc.Codigo)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<UnidadeConsumidora>()
                .Property(uc => uc.Concessionaria)
                .IsRequired();

            modelBuilder.Entity<UnidadeConsumidora>()
                .Property(uc => uc.Ativo)
                .IsRequired();

            // Relacionamentos
            modelBuilder.Entity<UnidadeConsumidora>()
                .HasOne(uc => uc.Cooperado)
                .WithMany(c => c.UnidadesConsumidoras)
                .HasForeignKey(uc => uc.CooperadoId)
                .IsRequired();

            modelBuilder.Entity<UnidadeConsumidora>()
                .HasOne(uc => uc.Endereco)
                .WithOne()
                .HasForeignKey<Endereco>(e => e.Id)
                .IsRequired();
        }
    }
}
