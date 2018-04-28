using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries.Course
{
    public interface ICourseQuerySingleHandler<T> where T : class
    {
        Core.Models.School.Course Handle(T query);
        Task<Core.Models.School.Course> HandleAsync(T query);
    }
}
