using api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Data
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
            modelBuilder.Entity<Endereco>().HasData(new Endereco
            {
                Id = -1,
                Cep = "00000-000",
                Estado = "MG",
                Cidade = "Belo Horizonte",
                Logradouro = "Rua Fulano de tal, Bairro Beltrano",
                Numero = 31
            });


            modelBuilder.Entity<Cliente>().HasData(new Cliente
            {
                Id = -1,
                Nome = "Primeiro Usuario",
                Cpf = "111.111.111-11",
                DiaDeNascimento = DateTime.Now,
                TipoDeUsuario = EnumTipoDeUsuario.CLIENTE,
                EnderecoId = -1
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}