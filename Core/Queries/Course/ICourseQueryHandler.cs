using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries.Course
{
    public interface ICourseQueryHandler<T> where T : class
    {
        IEnumerable<Models.School.Course> Handle(T query);
        Task<IEnumerable<Models.School.Course>> HandleAsync(T query);
    }
}
