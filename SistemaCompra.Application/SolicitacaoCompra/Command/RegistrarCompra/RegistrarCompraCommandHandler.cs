using MediatR;
using SistemaCompra.Application.Produto.Command.RegistrarProduto;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
   
        public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
        {
            private readonly SolicitacaoCompraAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository;

            public RegistrarCompraCommandHandler(SolicitacaoCompraAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
            {
                this.solicitacaoCompraRepository = solicitacaoCompraRepository;
            }

            public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
            {
                var solicitacao = new SolicitacaoCompraAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);
                solicitacao.RegistrarCompra(request.Itens);
                solicitacaoCompraRepository.RegistrarCompra(solicitacao);
                Commit();
                PublishEvents(solicitacao.Events);
                return Task.FromResult(true);
            }
        }
    
}
