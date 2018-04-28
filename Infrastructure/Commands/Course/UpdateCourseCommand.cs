using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Core.Commands.Course;
using Infrastructure.Data;

namespace Infrastructure.Commands.Course
{
    public class UpdateCourseCommand : CommandBase, IUpdateCourseCommand<int>
    {
        public UpdateCourseCommand(SchoolDbContext context) : base(context) { }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public int Handle()
        {
            var course = Context.Course.Find(CourseId);
            if (course != null)
            {
                course.Title = Title;
                course.Credits = Credits;
                course.DepartmentId = DepartmentId;
            }

            return Context.SaveChanges();
        }

        public async Task<int> HandleAsync()
        {
            var course = await Context.Course.FindAsync(CourseId);
            if (course != null)
            {
                course.Title = Title;
                course.Credits = Credits;
                course.DepartmentId = DepartmentId;
            }

            return await Context.SaveChangesAsync();
        }
    }
}
