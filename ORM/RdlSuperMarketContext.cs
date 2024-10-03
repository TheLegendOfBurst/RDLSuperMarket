using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RDLSuperMarket.ORM;

public partial class RdlSuperMarketContext : DbContext
{
    public RdlSuperMarketContext()
    {
    }

    public RdlSuperMarketContext(DbContextOptions<RdlSuperMarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbEndereco> TbEnderecos { get; set; }

    public virtual DbSet<TbProduto> TbProdutos { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    public virtual DbSet<TbVenda> TbVenda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAB205_2\\SQLEXPRESS;Database=RDL_SuperMarket;User Id=RDL_SuperMarket;Password=RDL271125;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.ToTable("Tb_Cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Documentoid).HasColumnName("documentoid");
            entity.Property(e => e.Endereco)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone).HasColumnName("telefone");
        });

        modelBuilder.Entity<TbEndereco>(entity =>
        {
            entity.ToTable("Tb_Endereco");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cep).HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cidade");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fkcliente).HasColumnName("fkcliente");
            entity.Property(e => e.Logadouro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("logadouro");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Pontoreferencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pontoreferencia");

            entity.HasOne(d => d.FkclienteNavigation).WithMany(p => p.TbEnderecos)
                .HasForeignKey(d => d.Fkcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tb_Endereco_Tb_Cliente");
        });

        modelBuilder.Entity<TbProduto>(entity =>
        {
            entity.ToTable("Tb_Produtos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Notaff).HasColumnName("notaff");
            entity.Property(e => e.Preco)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("preco");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.ToTable("Tb_usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Senha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("senha");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<TbVenda>(entity =>
        {
            entity.ToTable("Tb_Venda");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Fkcliente).HasColumnName("fkcliente");
            entity.Property(e => e.Fkproduto).HasColumnName("fkproduto");
            entity.Property(e => e.Notafv).HasColumnName("notafv");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.FkclienteNavigation).WithMany(p => p.TbVenda)
                .HasForeignKey(d => d.Fkcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tb_Venda_Tb_Cliente");

            entity.HasOne(d => d.FkprodutoNavigation).WithMany(p => p.TbVenda)
                .HasForeignKey(d => d.Fkproduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tb_Venda_Tb_Produtos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
