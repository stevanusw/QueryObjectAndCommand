using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public interface ICommandHandlerAsync<TReturn>
    {
        Task<TReturn> HandleAsync();
    }
}
