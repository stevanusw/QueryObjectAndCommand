using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Core.Queries.Course;
using Infrastructure.Data;

namespace Infrastructure.Queries.Course
{
    public class GetCourseByIdQueryHandler : ICourseQuerySingleHandler<Core.Queries.Course.GetCourseByIdQuery>
    {
        private readonly SchoolDbContext _context;

        public GetCourseByIdQueryHandler(SchoolDbContext context)
        {
            _context = context;
        }

        public Core.Models.School.Course Handle(Core.Queries.Course.GetCourseByIdQuery query)
        {
            if (query.IncludeData)
            {
                return _context.Course.Include(c => c.CourseInstructor).Include(c => c.Department).Include(c => c.OnlineCourse).Include(c => c.OnsiteCourse).Include(c => c.StudentGrade).SingleOrDefault(c => c.CourseId == query.Id);
            }

            return _context.Course.Find(query.Id);
        }

        public Task<Core.Models.School.Course> HandleAsync(Core.Queries.Course.GetCourseByIdQuery query)
        {
            if (query.IncludeData)
            {
                return _context.Course.Include(c => c.CourseInstructor).Include(c => c.Department).Include(c => c.OnlineCourse).Include(c => c.OnsiteCourse).Include(c => c.StudentGrade).SingleOrDefaultAsync(c => c.CourseId == query.Id);
            }

            return _context.Course.FindAsync(query.Id);
        }
    }
}
