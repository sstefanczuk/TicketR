using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicketR.Common.Core.Abstract
{
    public interface IBus
    {
        Task<TResponse> RunQuery<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken));
        Task<TResponse> RunCommand<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken = default(CancellationToken));
        Task RunCommand(ICommand request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
