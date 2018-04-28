using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands
{
    public interface IQueryHandler<out TResult> : IQueryHandlerBase
    {
        TResult Handle();
    }
}
