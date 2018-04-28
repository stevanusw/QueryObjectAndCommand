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
    public class GetAllCoursesQueryHandler : ICourseQueryHandler<Core.Queries.Course.GetAllCoursesQuery>
    {
        private readonly SchoolDbContext _context;

        public GetAllCoursesQueryHandler(SchoolDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Core.Models.School.Course> Handle(Core.Queries.Course.GetAllCoursesQuery query)
        {
            if (query.IncludeData)
            {
                return _context.Course.Include(c => c.CourseInstructor).Include(c => c.Department).Include(c => c.OnlineCourse).Include(c => c.OnsiteCourse).Include(c => c.StudentGrade).ToList();
            }

            return _context.Course.ToList();
        }

        public async Task<IEnumerable<Core.Models.School.Course>> HandleAsync(Core.Queries.Course.GetAllCoursesQuery query)
        {
            if (query.IncludeData)
            {
                return await _context.Course.Include(c => c.CourseInstructor).Include(c => c.Department).Include(c => c.OnlineCourse).Include(c => c.OnsiteCourse).Include(c => c.StudentGrade).ToListAsync();
            }

            return await _context.Course.ToListAsync();
        }
    }
}
