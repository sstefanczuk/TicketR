using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketR.Common.Core.Abstract;

namespace TicketR.Common.Core
{
    public class Bus : IBus
    {
        private readonly IMediator _mediator;
        private readonly ILogger<Bus> _logger;

        public Bus(IMediator mediator, ILogger<Bus> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<TResponse> RunCommand<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _mediator.Send<TResponse>(request, cancellationToken);
        }

        public async Task RunCommand(ICommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.Send(request, cancellationToken);
        }

        public async Task<TResponse> RunQuery<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _mediator.Send<TResponse>(request, cancellationToken);
        }
    }
}
