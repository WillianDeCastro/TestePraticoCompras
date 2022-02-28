using System;
using System.Linq;
using SolCompAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : SolCompAgg.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this.context = context;
        }

        public void RegistrarCompra(Domain.SolicitacaoCompraAggregate.SolicitacaoCompra entity)
        {
            context.Set<SolCompAgg.SolicitacaoCompra>().Add(entity);
        }
    }
}
