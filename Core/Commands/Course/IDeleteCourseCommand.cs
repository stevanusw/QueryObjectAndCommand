using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands.Course
{
    public interface IUpdateCourseCommand<TReturn> : ICommandHandler<TReturn>, ICommandHandlerAsync<TReturn>
    {
    }
}
