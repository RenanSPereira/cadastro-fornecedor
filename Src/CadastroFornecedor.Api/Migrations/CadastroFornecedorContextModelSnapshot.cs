// <auto-generated />
using System;
using CadastroFornecedor.Api.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroFornecedor.Api.Migrations
{
    [DbContext(typeof(CadastroFornecedorContext))]
    partial class CadastroFornecedorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("CadastroFornecedor.Api.Domain.Entity.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Excluido")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoFornecedor")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Fornecedor", (string)null);
                });

            modelBuilder.Entity("CadastroFornecedor.Api.Domain.Entity.Fornecedor", b =>
                {
                    b.OwnsOne("CadastroFornecedor.Api.Domain.ValueObject.Cnpj", "Cnpj", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.WithOwner()
                                .HasForeignKey("FornecedorId");
                        });

                    b.OwnsOne("CadastroFornecedor.Api.Domain.ValueObject.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.WithOwner()
                                .HasForeignKey("FornecedorId");
                        });

                    b.Navigation("Cnpj")
                        .IsRequired();

                    b.Navigation("Endereco")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
