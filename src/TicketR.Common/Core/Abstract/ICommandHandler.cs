using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TicketR.Common.Core.Abstract
{
    public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : ICommand<TResponse>

    {
    }

    public interface ICommandHandler<in TRequest> : IRequestHandler<TRequest>
        where TRequest : ICommand
    {
    }
}