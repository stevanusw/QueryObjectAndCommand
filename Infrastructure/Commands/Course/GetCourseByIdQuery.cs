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
    public class GetCourseByIdQuery : QueryBase, IGetCourseByIdQuery
    {
        public GetCourseByIdQuery(SchoolDbContext context) : base(context) { }

        public bool IncludeData { get; set; }
        public int Id { get; set; }

        public Core.Models.School.Course Handle()
        {
            if (IncludeData)
            {
                return Context.Course.Include(c => c.CourseInstructor).Include(c => c.Department).Include(c => c.OnlineCourse).Include(c => c.OnsiteCourse).Include(c => c.StudentGrade).SingleOrDefault(c => c.CourseId == Id);
            }

            return Context.Course.Find(Id);
        }

        public Task<Core.Models.School.Course> HandleAsync()
        {
            if (IncludeData)
            {
                return Context.Course.Include(c => c.CourseInstructor).Include(c => c.Department).Include(c => c.OnlineCourse).Include(c => c.OnsiteCourse).Include(c => c.StudentGrade).SingleOrDefaultAsync(c => c.CourseId == Id);
            }

            return Context.Course.FindAsync(Id);
        }
    }
}
