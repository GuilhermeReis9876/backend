﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Infrastructure.Data;

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210219015754_fixDataLocacaoSeeder")]
    partial class fixDataLocacaoSeeder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api.Domain.Models.CheckList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CheckListInicial")
                        .HasColumnType("bit");

                    b.Property<bool>("EstaComTanqueCheio")
                        .HasColumnType("bit");

                    b.Property<bool>("EstaLimpo")
                        .HasColumnType("bit");

                    b.Property<bool>("EstaSemAmassados")
                        .HasColumnType("bit");

                    b.Property<bool>("EstaSemArranhoes")
                        .HasColumnType("bit");

                    b.Property<int>("LocacaoVeiculoId")
                        .HasColumnType("int");

                    b.Property<int>("OperadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocacaoVeiculoId");

                    b.HasIndex("OperadorId");

                    b.ToTable("CheckLists");
                });

            modelBuilder.Entity("api.Domain.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DiaDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("TipoDeUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "063.923.720-75",
                            DiaDeNascimento = new DateTime(1992, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Fulano da Silva Cliente",
                            TipoDeUsuario = 1
                        });
                });

            modelBuilder.Entity("api.Domain.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("api.Domain.Models.LocacaoVeiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TotalHoras")
                        .HasColumnType("int");

                    b.Property<double>("ValorFinal")
                        .HasColumnType("float");

                    b.Property<double>("ValorLocacao")
                        .HasColumnType("float");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("LocacaoVeiculos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClienteId = 1,
                            DataDevolucao = new DateTime(2021, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataLocacao = new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0,
                            TotalHoras = 48,
                            ValorFinal = 0.0,
                            ValorLocacao = 91.900000000000006,
                            VeiculoId = 1
                        });
                });

            modelBuilder.Entity("api.Domain.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fiat"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Wolkswagen"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Chevrolet"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Nissan"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Toyota"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Jeep"
                        },
                        new
                        {
                            Id = 8,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Hyundai"
                        });
                });

            modelBuilder.Entity("api.Domain.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Modelos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MarcaId = 1,
                            Name = "Uno"
                        },
                        new
                        {
                            Id = 2,
                            MarcaId = 1,
                            Name = "Palio Attractive"
                        },
                        new
                        {
                            Id = 3,
                            MarcaId = 1,
                            Name = "Argo"
                        },
                        new
                        {
                            Id = 4,
                            MarcaId = 1,
                            Name = "Novo Fiat Strada"
                        },
                        new
                        {
                            Id = 5,
                            MarcaId = 2,
                            Name = "Gol"
                        },
                        new
                        {
                            Id = 6,
                            MarcaId = 2,
                            Name = "Up"
                        },
                        new
                        {
                            Id = 7,
                            MarcaId = 2,
                            Name = "Voyage"
                        },
                        new
                        {
                            Id = 8,
                            MarcaId = 2,
                            Name = "Jetta"
                        },
                        new
                        {
                            Id = 9,
                            MarcaId = 1,
                            Name = "Moby"
                        },
                        new
                        {
                            Id = 10,
                            MarcaId = 9,
                            Name = "HB-20"
                        },
                        new
                        {
                            Id = 11,
                            MarcaId = 2,
                            Name = "Saveiro"
                        },
                        new
                        {
                            Id = 12,
                            MarcaId = 2,
                            Name = "Virtus"
                        },
                        new
                        {
                            Id = 13,
                            MarcaId = 4,
                            Name = "Versa"
                        },
                        new
                        {
                            Id = 14,
                            MarcaId = 5,
                            Name = "Eco Sport"
                        },
                        new
                        {
                            Id = 15,
                            MarcaId = 2,
                            Name = "Polo"
                        },
                        new
                        {
                            Id = 16,
                            MarcaId = 1,
                            Name = "Toro"
                        },
                        new
                        {
                            Id = 17,
                            MarcaId = 6,
                            Name = "Hylux"
                        },
                        new
                        {
                            Id = 18,
                            MarcaId = 7,
                            Name = "Compass"
                        },
                        new
                        {
                            Id = 19,
                            MarcaId = 8,
                            Name = "X1"
                        },
                        new
                        {
                            Id = 20,
                            MarcaId = 2,
                            Name = "Golf"
                        });
                });

            modelBuilder.Entity("api.Domain.Models.Operador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DiaDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Matricula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("TipoDeUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Operadores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DiaDeNascimento = new DateTime(1990, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = "123456",
                            Nome = "Beltrano da Silva Operador",
                            TipoDeUsuario = 0
                        });
                });

            modelBuilder.Entity("api.Domain.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Ano")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EstaLocado")
                        .HasColumnType("bit");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kilometragem")
                        .HasColumnType("int");

                    b.Property<int>("LimitePortaMalas")
                        .HasColumnType("int");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.Property<string>("Motor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDeCombustivel")
                        .HasColumnType("int");

                    b.Property<int>("TipoDeVeiculo")
                        .HasColumnType("int");

                    b.Property<double>("ValorHora")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ModeloId");

                    b.ToTable("Veiculos");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/moby.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 200,
                            ModeloId = 9,
                            Motor = "1.0",
                            Placa = "PUA-1049",
                            TipoDeCombustivel = 3,
                            TipoDeVeiculo = 0,
                            ValorHora = 4.1200000000000001
                        },
                        new
                        {
                            Id = 3,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/gol.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 210,
                            ModeloId = 5,
                            Motor = "1.0",
                            Placa = "FFF-5256",
                            TipoDeCombustivel = 3,
                            TipoDeVeiculo = 0,
                            ValorHora = 5.25
                        },
                        new
                        {
                            Id = 4,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/hb20.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 180,
                            ModeloId = 10,
                            Motor = "1.0",
                            Placa = "HOK-5912",
                            TipoDeCombustivel = 3,
                            TipoDeVeiculo = 0,
                            ValorHora = 6.3200000000000003
                        },
                        new
                        {
                            Id = 5,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/saveiro.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 220,
                            ModeloId = 11,
                            Motor = "1.0",
                            Placa = "OMF-5162",
                            TipoDeCombustivel = 3,
                            TipoDeVeiculo = 0,
                            ValorHora = 6.3200000000000003
                        },
                        new
                        {
                            Id = 6,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/voyage.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 180,
                            ModeloId = 7,
                            Motor = "1.0",
                            Placa = "PUT-4971",
                            TipoDeCombustivel = 3,
                            TipoDeVeiculo = 0,
                            ValorHora = 7.21
                        },
                        new
                        {
                            Id = 7,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/virtus.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 220,
                            ModeloId = 12,
                            Motor = "1.4",
                            Placa = "JKG-4971",
                            TipoDeCombustivel = 3,
                            TipoDeVeiculo = 1,
                            ValorHora = 8.3200000000000003
                        },
                        new
                        {
                            Id = 8,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/versa.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 220,
                            ModeloId = 13,
                            Motor = "2.0",
                            Placa = "UIO-4971",
                            TipoDeCombustivel = 3,
                            TipoDeVeiculo = 1,
                            ValorHora = 8.9800000000000004
                        },
                        new
                        {
                            Id = 9,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/ecosport.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 300,
                            ModeloId = 14,
                            Motor = "1.6",
                            Placa = "MNK-4971",
                            TipoDeCombustivel = 3,
                            TipoDeVeiculo = 1,
                            ValorHora = 8.9800000000000004
                        },
                        new
                        {
                            Id = 10,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/polo.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 250,
                            ModeloId = 15,
                            Motor = "1.4",
                            Placa = "ZAQ-4971",
                            TipoDeCombustivel = 3,
                            TipoDeVeiculo = 1,
                            ValorHora = 8.9800000000000004
                        },
                        new
                        {
                            Id = 11,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/toro.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 250,
                            ModeloId = 16,
                            Motor = "2.0",
                            Placa = "EFW-4971",
                            TipoDeCombustivel = 2,
                            TipoDeVeiculo = 1,
                            ValorHora = 8.9800000000000004
                        },
                        new
                        {
                            Id = 12,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/hylux.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 400,
                            ModeloId = 17,
                            Motor = "3.2",
                            Placa = "PDL-4971",
                            TipoDeCombustivel = 2,
                            TipoDeVeiculo = 2,
                            ValorHora = 9.5600000000000005
                        },
                        new
                        {
                            Id = 13,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/compass.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 350,
                            ModeloId = 18,
                            Motor = "2.0",
                            Placa = "YHT-4515",
                            TipoDeCombustivel = 3,
                            TipoDeVeiculo = 2,
                            ValorHora = 9.5600000000000005
                        },
                        new
                        {
                            Id = 14,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/x1.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 380,
                            ModeloId = 19,
                            Motor = "2.2",
                            Placa = "YHT-6723",
                            TipoDeCombustivel = 0,
                            TipoDeVeiculo = 2,
                            ValorHora = 12.98
                        },
                        new
                        {
                            Id = 15,
                            Ano = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstaLocado = false,
                            Imagem = "https://localiza.vercel.app/utils/img/golf.png",
                            Kilometragem = 0,
                            LimitePortaMalas = 250,
                            ModeloId = 20,
                            Motor = "1.4",
                            Placa = "YHT-1234",
                            TipoDeCombustivel = 3,
                            TipoDeVeiculo = 2,
                            ValorHora = 9.2100000000000009
                        });
                });

            modelBuilder.Entity("api.Domain.Models.CheckList", b =>
                {
                    b.HasOne("api.Domain.Models.LocacaoVeiculo", "LocacaoVeiculo")
                        .WithMany()
                        .HasForeignKey("LocacaoVeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Domain.Models.Operador", "Operador")
                        .WithMany()
                        .HasForeignKey("OperadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocacaoVeiculo");

                    b.Navigation("Operador");
                });

            modelBuilder.Entity("api.Domain.Models.Cliente", b =>
                {
                    b.HasOne("api.Domain.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("api.Domain.Models.LocacaoVeiculo", b =>
                {
                    b.HasOne("api.Domain.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Domain.Models.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("api.Domain.Models.Modelo", b =>
                {
                    b.HasOne("api.Domain.Models.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("api.Domain.Models.Operador", b =>
                {
                    b.HasOne("api.Domain.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("api.Domain.Models.Veiculo", b =>
                {
                    b.HasOne("api.Domain.Models.Modelo", "Modelo")
                        .WithMany()
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("api.Domain.Models.Marca", b =>
                {
                    b.Navigation("Modelos");
                });
#pragma warning restore 612, 618
        }
    }
}
