using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands
{
    public interface IQueryHandlerBase
    {
        bool IncludeData { get; set; }
    }
}
