﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands.Course
{
    public interface IDeleteCourseCommand<TReturn> : ICommandHandler<TReturn>, ICommandHandlerAsync<TReturn>
    {
    }
}
