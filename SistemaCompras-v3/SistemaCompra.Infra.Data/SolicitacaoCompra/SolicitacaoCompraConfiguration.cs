using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolCompAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    internal class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolCompAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolCompAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");
            builder.OwnsOne(c => c.TotalGeral, b => b.Property("Value").HasColumnName("TotalGeral")); ;
        }
    }
}
