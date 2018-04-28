using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands
{
    public interface ICommandHandler<out TReturn>
    {
        TReturn Handle();
    }
}
