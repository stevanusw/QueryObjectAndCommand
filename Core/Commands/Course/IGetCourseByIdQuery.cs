using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands.Course
{
    public interface IGetCourseByIdQuery : IQueryHandler<Core.Models.School.Course>, IQueryHandlerAsync<Core.Models.School.Course>
    {
        int Id { get; set; }
    }
}
