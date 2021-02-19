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


            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 3,
                Name = "Chevrolet"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 4,
                Name = "Nissan"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 5,
                Name = "Ford"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 6,
                Name = "Toyota"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 7,
                Name = "Jeep"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 8,
                Name = "BMW"
            });

            modelBuilder.Entity<Marca>().HasData(new Marca
            {
                Id = 9,
                Name = "Hyundai"
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
                Name = "Gol",
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


            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 9,
                Name = "Moby",
                MarcaId = 1
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 10,
                Name = "HB-20",
                MarcaId = 9
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 11,
                Name = "Saveiro",
                MarcaId = 2
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 12,
                Name = "Virtus",
                MarcaId = 2
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 13,
                Name = "Versa",
                MarcaId = 4
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 14,
                Name = "Eco Sport",
                MarcaId = 5
            });


            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 15,
                Name = "Polo",
                MarcaId = 2
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 16,
                Name = "Toro",
                MarcaId = 1
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 17,
                Name = "Hylux",
                MarcaId = 6
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 18,
                Name = "Compass",
                MarcaId = 7
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 19,
                Name = "X1",
                MarcaId = 8
            });

            modelBuilder.Entity<Modelo>().HasData(new Modelo
            {
                Id = 20,
                Name = "Golf",
                MarcaId = 2
            });


            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 2,
                Ano = new System.DateTime(2013, 01, 01),
                ModeloId = 9, //moby
                Placa = "PUA-1049",
                TipoDeCombustivel = EnumTipoDeCombustivel.FLEX,
                TipoDeVeiculo = EnumTipoDeVeiculo.BASICO,
                ValorHora = 4.12,
                LimitePortaMalas = 200,
                Motor = "1.0",
                Imagem = "https://localiza.vercel.app/utils/img/moby.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 3,
                Ano = new System.DateTime(2013, 01, 01),
                ModeloId = 5, // gol
                Placa = "FFF-5256",
                TipoDeCombustivel = EnumTipoDeCombustivel.FLEX,
                TipoDeVeiculo = EnumTipoDeVeiculo.BASICO,
                ValorHora = 5.25,
                LimitePortaMalas = 210,
                Motor = "1.0",
                Imagem = "https://localiza.vercel.app/utils/img/gol.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 4,
                Ano = new System.DateTime(2013, 01, 01),
                ModeloId = 10, // HB-20
                Placa = "HOK-5912",
                TipoDeCombustivel = EnumTipoDeCombustivel.FLEX,
                TipoDeVeiculo = EnumTipoDeVeiculo.BASICO,
                ValorHora = 6.32,
                LimitePortaMalas = 180,
                Motor = "1.0",
                Imagem = "https://localiza.vercel.app/utils/img/hb20.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 5,
                Ano = new System.DateTime(2013, 01, 01),
                ModeloId = 11, // SAVEIRO
                Placa = "OMF-5162",
                TipoDeCombustivel = EnumTipoDeCombustivel.FLEX,
                TipoDeVeiculo = EnumTipoDeVeiculo.BASICO,
                ValorHora = 6.32,
                LimitePortaMalas = 220,
                Motor = "1.0",
                Imagem = "https://localiza.vercel.app/utils/img/saveiro.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 6,
                Ano = new System.DateTime(2013, 01, 01),
                ModeloId = 7, // Voyage
                Placa = "PUT-4971",
                TipoDeCombustivel = EnumTipoDeCombustivel.FLEX,
                TipoDeVeiculo = EnumTipoDeVeiculo.BASICO,
                ValorHora = 7.21,
                LimitePortaMalas = 180,
                Motor = "1.0",
                Imagem = "https://localiza.vercel.app/utils/img/voyage.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 7,
                Ano = new System.DateTime(2013, 01, 01),
                ModeloId = 12, // Virtus
                Placa = "JKG-4971",
                TipoDeCombustivel = EnumTipoDeCombustivel.FLEX,
                TipoDeVeiculo = EnumTipoDeVeiculo.COMPLETO,
                ValorHora = 8.32,
                LimitePortaMalas = 220,
                Motor = "1.4",
                Imagem = "https://localiza.vercel.app/utils/img/virtus.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 8,
                Ano = new System.DateTime(2013, 01, 01),
                Placa = "UIO-4971",
                ModeloId = 13, // VERSA
                TipoDeCombustivel = EnumTipoDeCombustivel.FLEX,
                TipoDeVeiculo = EnumTipoDeVeiculo.COMPLETO,
                ValorHora = 8.98,
                LimitePortaMalas = 220,
                Motor = "2.0",
                Imagem = "https://localiza.vercel.app/utils/img/versa.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 9,
                Ano = new System.DateTime(2013, 01, 01),
                Placa = "MNK-4971",
                ModeloId = 14, // ECO-SPORT
                TipoDeCombustivel = EnumTipoDeCombustivel.FLEX,
                TipoDeVeiculo = EnumTipoDeVeiculo.COMPLETO,
                ValorHora = 8.98,
                LimitePortaMalas = 300,
                Motor = "1.6",
                Imagem = "https://localiza.vercel.app/utils/img/ecosport.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 10,
                Ano = new System.DateTime(2013, 01, 01),
                Placa = "ZAQ-4971",
                ModeloId = 15, // POLO
                TipoDeCombustivel = EnumTipoDeCombustivel.FLEX,
                TipoDeVeiculo = EnumTipoDeVeiculo.COMPLETO,
                ValorHora = 8.98,
                LimitePortaMalas = 250,
                Motor = "1.4",
                Imagem = "https://localiza.vercel.app/utils/img/polo.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 11,
                Ano = new System.DateTime(2013, 01, 01),
                Placa = "EFW-4971",
                ModeloId = 16, // TORO
                TipoDeCombustivel = EnumTipoDeCombustivel.DIESEL,
                TipoDeVeiculo = EnumTipoDeVeiculo.COMPLETO,
                ValorHora = 8.98,
                LimitePortaMalas = 250,
                Motor = "2.0",
                Imagem = "https://localiza.vercel.app/utils/img/toro.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 12,
                Ano = new System.DateTime(2013, 01, 01),
                Placa = "PDL-4971",
                ModeloId = 17, // HYLUX
                TipoDeCombustivel = EnumTipoDeCombustivel.DIESEL,
                TipoDeVeiculo = EnumTipoDeVeiculo.LUXO,
                ValorHora = 9.56,
                LimitePortaMalas = 400,
                Motor = "3.2",
                Imagem = "https://localiza.vercel.app/utils/img/hylux.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 13,
                Ano = new System.DateTime(2013, 01, 01),
                Placa = "YHT-4515",
                ModeloId = 18, // COMPASS
                TipoDeCombustivel = EnumTipoDeCombustivel.FLEX,
                TipoDeVeiculo = EnumTipoDeVeiculo.LUXO,
                ValorHora = 9.56,
                LimitePortaMalas = 350,
                Motor = "2.0",
                Imagem = "https://localiza.vercel.app/utils/img/compass.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 14,
                Ano = new System.DateTime(2013, 01, 01),
                Placa = "YHT-6723",
                ModeloId = 19, // X1
                TipoDeCombustivel = EnumTipoDeCombustivel.GASOLINA,
                TipoDeVeiculo = EnumTipoDeVeiculo.LUXO,
                ValorHora = 12.98,
                LimitePortaMalas = 380,
                Motor = "2.2",
                Imagem = "https://localiza.vercel.app/utils/img/x1.png"

            });

            modelBuilder.Entity<Veiculo>().HasData(new Veiculo
            {
                Id = 15,
                Ano = new System.DateTime(2013, 01, 01),
                Placa = "YHT-1234",
                ModeloId = 20, // GOLF
                TipoDeCombustivel = EnumTipoDeCombustivel.FLEX,
                TipoDeVeiculo = EnumTipoDeVeiculo.LUXO,
                ValorHora = 9.21,
                LimitePortaMalas = 250,
                Motor = "1.4",
                Imagem = "https://localiza.vercel.app/utils/img/golf.png"

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


          

            modelBuilder.Entity<LocacaoVeiculo>().HasData(new LocacaoVeiculo
            {
                Id = 1,
                ClienteId = 1,
                VeiculoId = 1,
                DataLocacao = new System.DateTime(2021, 02, 20, 00, 00, 00),
                DataDevolucao = new System.DateTime(2021, 02, 24, 00, 00, 00),
                TotalHoras = 48,
                ValorLocacao = 91.90
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}