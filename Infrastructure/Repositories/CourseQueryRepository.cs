using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Core.Models.School;
using Core.Queries.Course;
using Infrastructure.Data;
using Infrastructure.Queries.Course;

namespace Infrastructure.Repositories
{
    public class CourseQueryRepository : ICourseQueryRepository
    {
        private readonly SchoolDbContext _context;

        public CourseQueryRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> Get<T>(T query) where T : class
        {
            switch (typeof(T).Name)
            {
                case nameof(Core.Queries.Course.GetAllCoursesQuery):
                    return new GetAllCoursesQueryHandler(_context).Handle(query as Core.Queries.Course.GetAllCoursesQuery);

                default:
                    throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Course>> GetAsync<T>(T query) where T : class
        {
            switch (typeof(T).Name)
            {
                case nameof(Core.Queries.Course.GetAllCoursesQuery):
                    return await new GetAllCoursesQueryHandler(_context).HandleAsync(query as Core.Queries.Course.GetAllCoursesQuery);

                default:
                    throw new NotImplementedException();
            }
        }

        public Course GetSingle<T>(T query) where T : class
        {
            switch (typeof(T).Name)
            {
                case nameof(Core.Queries.Course.GetCourseByIdQuery):
                    return new GetCourseByIdQueryHandler(_context).Handle(query as Core.Queries.Course.GetCourseByIdQuery);

                default:
                    throw new NotImplementedException();
            }
        }

        public async Task<Course> GetSingleAsync<T>(T query) where T : class
        {
            switch (typeof(T).Name)
            {
                case nameof(Core.Queries.Course.GetCourseByIdQuery):
                    return await new GetCourseByIdQueryHandler(_context).HandleAsync(query as Core.Queries.Course.GetCourseByIdQuery);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
