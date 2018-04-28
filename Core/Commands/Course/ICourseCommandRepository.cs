using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands.Course
{
    public interface ICourseCommandRepository
    {
        IEnumerable<Models.School.Course> Get<T>(T query) where T : IQueryHandler<IEnumerable<Models.School.Course>>;
        Task<IEnumerable<Models.School.Course>> GetAsync<T>(T query) where T : IQueryHandlerAsync<IEnumerable<Models.School.Course>>;

        Models.School.Course GetSingle<T>(T query) where T : IQueryHandler<Models.School.Course>;
        Task<Models.School.Course> GetSingleAsync<T>(T query) where T : IQueryHandlerAsync<Models.School.Course>;

        int Execute<T>(T command) where T : ICommandHandler<int>;
        Task<int> ExecuteAsync<T>(T command) where T : ICommandHandlerAsync<int>;
    }
}
