using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Domain.Core.Model;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<SolicitacaoCompraAgg.SolicitacaoCompra>
    {

        public void Configure(EntityTypeBuilder<SolicitacaoCompraAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");
            builder.HasMany(c => c.Itens);
            builder.OwnsOne(c => c.TotalGeral, b => b.Property("Value").HasColumnName("TotalGeral"));
            builder.OwnsOne(c => c.NomeFornecedor, b => b.Property("Nome").HasColumnName("NomeFornecedor")).HasNoKey();
            builder.OwnsOne(c => c.UsuarioSolicitante, b => b.Property("Nome").HasColumnName("UsuarioSolicitante")).HasNoKey();

        }
    }
}
