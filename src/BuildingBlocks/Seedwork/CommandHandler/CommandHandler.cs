
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace Seedwork.CommandHandler
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Response> Send<Command, Response>(Command command)
            where Command : IRequest<Response>
            where Response : BaseResponse
        {
            try
            {
                return await _mediator.Send(command);
            }
            catch(Exception ex)
            {
                return (Response)ExceptionHandler(ex);
            }
        }

        private BaseResponse ExceptionHandler(Exception ex)
        {
             var response = new BaseResponse();
            response.AddError(ex);

            return response;
        }
    }
}