using System.Threading.Tasks;
using MediatR;

namespace Seedwork.CommandHandler
{
    public interface ICommandHandler
    {
        /// <summary>
        /// Send any command to handler.
        /// <br/> The handler handles with exceptions and messages.
        /// </summary>
        /// <param name="command"></param>
        /// <typeparam name="Command"></typeparam>
        /// <typeparam name="Response"></typeparam>
        /// <returns></returns>
         Task<Response> Send<Command,Response>(Command command) 
            where Command : IRequest<Response>
            where Response : BaseResponse;
    }
}