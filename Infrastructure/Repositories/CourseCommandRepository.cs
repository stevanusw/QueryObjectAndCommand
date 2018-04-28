using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Core.Commands;
using Core.Commands.Course;
using Core.Models.School;

namespace Infrastructure.Repositories
{
    public class CourseCommandRepository : ICourseCommandRepository
    {
        public IEnumerable<Course> Get<T>(T query) where T : IQueryHandler<IEnumerable<Course>>
        {
            return query.Handle();
        }

        public async Task<IEnumerable<Course>> GetAsync<T>(T query) where T : IQueryHandlerAsync<IEnumerable<Course>>
        {
            return await query.HandleAsync();
        }

        public Course GetSingle<T>(T query) where T : IQueryHandler<Course>
        {
            return query.Handle();
        }

        public async Task<Course> GetSingleAsync<T>(T query) where T : IQueryHandlerAsync<Course>
        {
            return await query.HandleAsync();
        }

        public int Execute<T>(T command) where T : ICommandHandler<int>
        {
            return command.Handle();
        }

        public async Task<int> ExecuteAsync<T>(T command) where T : ICommandHandlerAsync<int>
        {
            return await command.HandleAsync();
        }
    }
}
