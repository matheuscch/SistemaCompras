using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.ProdutoAggregate.Events;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        [NotMapped]
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        [NotMapped]
        public CondicaoPagamento CondicaoPagamento { get; set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (!itens.Any()) throw new BusinessRuleException("A solicitação de compra deve possuir itens!");

            decimal count = 0;
            foreach (var item in itens)
            {
                count = count + item.ObterSubtotal().Value;
            }
            
            if(count >= 50000)
            {
                CondicaoPagamento = new CondicaoPagamento(30);
            }

            TotalGeral = new Money(count);

            AddEvent(new CompraRegistradaEvent(Id, itens.ToList(), TotalGeral.Value));
        }
    }
}
