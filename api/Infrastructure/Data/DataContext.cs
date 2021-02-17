using api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Operador> Operadores { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<LocacaoVeiculo> LocacaoVeiculos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 1,
                Name = "Fiat"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 2,
                Name = "Wolkswagen"
            });


            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 1,
                Name = "Uno",
                MarcaId = 1
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 2,
                Name = "Palio Attractive",
                MarcaId = 1
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 3,
                Name = "Argo",
                MarcaId = 1
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 4,
                Name = "Novo Fiat Strada",
                MarcaId = 1
            });


            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 5,
                Name = "Gol - Gen 5",
                MarcaId = 2
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 6,
                Name = "Up",
                MarcaId = 2
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 7,
                Name = "Voyage",
                MarcaId = 2
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 8,
                Name = "Jetta",
                MarcaId = 2
            });

            modelBuilder.Entity<Cliente>().HasData(new Cliente
            {
                Id = 1,
                Cpf = "063.923.720-75",
                DiaDeNascimento = new System.DateTime(1992, 12, 03),
                Nome = "Fulano da Silva Cliente",
                TipoDeUsuario = EnumTipoDeUsuario.CLIENTE,
            });

            modelBuilder.Entity<Operador>().HasData(new Operador
            {
                Id = 1,
                Matricula = "123456",
                DiaDeNascimento = new System.DateTime(1990, 10, 05),
                Nome = "Beltrano da Silva Operador",
                TipoDeUsuario = EnumTipoDeUsuario.OPERADOR,
            });


            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 1,
                Ano = new System.DateTime(2013, 01, 01),
                ModeloId = 7,
                Placa = "XXX-0909",
                TipoDeCombustivel = EnumTipoDeCombustivel.GASOLINA,
                TipoDeVeiculo = EnumTipoDeVeiculo.BASICO,
                ValorHora = 45.95

            });

            modelBuilder.Entity<LocacaoVeiculo>().HasData(new LocacaoVeiculo
            {
                Id = 1,
                ClienteId = 1,
                VeiculoId = 1,
                DataLocacao = new System.DateTime(2021, 02, 20, 00, 00, 00),
                DataDevolucao = new System.DateTime(2021, 04, 20, 00, 00, 00),
                TotalHoras = 48,
                ValorLocacao = 91.90
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}