using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public interface IQueryHandlerAsync<TResult> : IQueryHandlerBase
    {
        Task<TResult> HandleAsync();
    }
}
