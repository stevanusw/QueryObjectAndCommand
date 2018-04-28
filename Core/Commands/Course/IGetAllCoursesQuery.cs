using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands.Course
{
    public interface IGetAllCoursesQuery<in T> : IQueryHandler<IEnumerable<Core.Models.School.Course>>, IQueryHandlerAsync<IEnumerable<Core.Models.School.Course>>
    {
    }
}
