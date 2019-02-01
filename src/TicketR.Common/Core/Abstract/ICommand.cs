using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketR.Common.Core.Abstract
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
