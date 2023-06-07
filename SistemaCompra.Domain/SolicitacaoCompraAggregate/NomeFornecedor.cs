using SistemaCompra.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class NomeFornecedor
    {
        public Guid Id { get; protected set; }
        public string Nome { get; }

        private NomeFornecedor() { }

        public NomeFornecedor(string nome)
        {
            if (String.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
            if (nome.Length < 10) throw new BusinessRuleException("Nome de fornecedor deve ter pelo menos 10 caracteres.");
            Id = Guid.NewGuid();
            Nome = nome;
        }
    }
}
