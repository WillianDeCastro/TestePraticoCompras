using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.Produto.Command.AtualizarPreco;
using SistemaCompra.Application.Produto.Command.RegistrarProduto;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using SistemaCompra.Domain.ProdutoAggregate;
using System;

namespace SistemaCompra.API.SolicitacaoCompra
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpPost, Route("produto/comprar")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CadastrarCompra([FromBody] RegistrarCompraCommand registrarCompraCommand)
        {

            //
            for (int i = 0; i < registrarCompraCommand.Produtos.Count; i++)
            {
                registrarCompraCommand.Produtos[i].Produto = new Domain.ProdutoAggregate.Produto("Cedro", "Transversal 3/3", Categoria.Madeira.ToString(), 200);
            }

            _mediator.Send(registrarCompraCommand);
            return StatusCode(201);
        }

    }
}
