using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries.Course
{
    public interface ICourseQueryRepository
    {
        IEnumerable<Models.School.Course> Get<T>(T query) where T : class;
        Task<IEnumerable<Models.School.Course>> GetAsync<T>(T query) where T : class;

        Models.School.Course GetSingle<T>(T query) where T : class;
        Task<Models.School.Course> GetSingleAsync<T>(T query) where T : class;
    }
}
