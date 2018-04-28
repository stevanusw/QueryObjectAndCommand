using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Core.Commands.Course;
using Infrastructure.Data;

namespace Infrastructure.Commands.Course
{
    public class DeleteCourseCommand : CommandBase, IDeleteCourseCommand<int>
    {
        public DeleteCourseCommand(SchoolDbContext context) : base(context) { }

        public int CourseId { get; set; }

        public int Handle()
        {
            var course = Context.Course.Find(CourseId);

            Context.Remove(course);

            return Context.SaveChanges();
        }

        public async Task<int> HandleAsync()
        {
            var course = await Context.Course.FindAsync(CourseId);

            Context.Remove(course);

            return await Context.SaveChangesAsync();
        }
    }
}
