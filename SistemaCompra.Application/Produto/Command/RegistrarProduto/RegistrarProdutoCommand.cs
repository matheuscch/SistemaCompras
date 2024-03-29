﻿using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Application.Produto.Command.RegistrarProduto
{
    public class RegistrarProdutoCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
