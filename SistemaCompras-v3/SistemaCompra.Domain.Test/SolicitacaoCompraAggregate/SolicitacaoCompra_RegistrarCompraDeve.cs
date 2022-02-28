using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using Xunit;

namespace SistemaCompra.Domain.Test.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra_RegistrarCompraDeve
    {
        [Fact]
        public void DefinirPrazo30DiasAoComprarMais50mil()
        {
            //Dado
            var solicitacao = new SolicitacaoCompra("rodrigoasth", "rodrigoasth");
            var itens = new List<Item>();
            var produto = new Produto("Cedro", "Transversal 3/3", Categoria.Madeira.ToString(), 1001);
            itens.Add(new Item(produto, 50));

            //Quando
            solicitacao.RegistrarCompra(itens, 90);

            //Então
            Assert.Equal(30, solicitacao.CondicaoPagamento.Valor);
        }

        [Theory]
        [InlineData(5, 1000)]
        [InlineData(20, 200)]
        [InlineData(5, 500)]
        public void DeveManter_CondicaoPrazo_Ao_Comprar50mil_Ou_Menos(int qtdCompra, int preco)
        {
            //Dado
            IList<int> condicoesPossiveis = new List<int>() { 0, 60, 90 };

            var rnd = new Random();
            int pos = rnd.Next(0, 3);

            int condicao = condicoesPossiveis[pos];

            var solicitacao = new SolicitacaoCompra("rodrigoasth", "rodrigoasth");
            var itens = new List<Item>();
            var produto = new Produto("Cedro", "Transversal 3/3", Categoria.Madeira.ToString(), preco);
            itens.Add(new Item(produto, qtdCompra));

            //Quando
            solicitacao.RegistrarCompra(itens, condicao);

            //Então
            Assert.Equal(condicoesPossiveis[pos], solicitacao.CondicaoPagamento.Valor);
        }

        [Fact]
        public void NotificarErroQuandoNaoInformarItensCompra()
        {
            //Dado
            var solicitacao = new SolicitacaoCompra("rodrigoasth", "rodrigoasth");
            var itens = new List<Item>();

            //Quando 
            var ex = Assert.Throws<BusinessRuleException>(() => solicitacao.RegistrarCompra(itens, 30));

            //Então
            Assert.Equal("A solicitação de compra deve possuir itens!", ex.Message);
        }
    }
}
