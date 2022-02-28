using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Threading;
using System.Threading.Tasks;
using SolCompAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly SolCompAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository;

        public RegistrarCompraCommandHandler(SolCompAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.solicitacaoCompraRepository = solicitacaoCompraRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solCompra = new SolCompAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);

            solCompra.RegistrarCompra(request.Produtos, request.Condicao);
            solicitacaoCompraRepository.RegistrarCompra(solCompra);

            Commit();
            PublishEvents(solCompra.Events);

            return Task.FromResult(true);
        }
    }
}
