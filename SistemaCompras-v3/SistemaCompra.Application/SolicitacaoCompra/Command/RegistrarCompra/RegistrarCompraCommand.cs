using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public List<Item> Produtos { get; set; }
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public int Condicao { get; set; }
    }
}
