using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Core.Commands.Course;
using Infrastructure.Data;

namespace Infrastructure.Commands.Course
{
    public class GetAllCoursesQuery : QueryBase, IGetAllCoursesQuery<GetAllCoursesQuery>
    {
        public GetAllCoursesQuery(SchoolDbContext context) : base(context) { }

        public bool IncludeData { get; set; }

        public IEnumerable<Core.Models.School.Course> Handle()
        {
            if (IncludeData)
            {
                return Context.Course.Include(c => c.CourseInstructor).Include(c => c.Department).Include(c => c.OnlineCourse).Include(c => c.OnsiteCourse).Include(c => c.StudentGrade).ToList();
            }

            return Context.Course.ToList();
        }

        public async Task<IEnumerable<Core.Models.School.Course>> HandleAsync()
        {
            if (IncludeData)
            {
                return await Context.Course.Include(c => c.CourseInstructor).Include(c => c.Department).Include(c => c.OnlineCourse).Include(c => c.OnsiteCourse).Include(c => c.StudentGrade).ToListAsync();
            }

            return await Context.Course.ToListAsync();
        }
    }
}
