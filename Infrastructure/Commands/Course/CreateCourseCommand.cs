using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Core.Commands.Course;
using Infrastructure.Data;

namespace Infrastructure.Commands.Course
{
    public class CreateCourseCommand : CommandBase, ICreateCourseCommand<int>
    {
        public CreateCourseCommand(SchoolDbContext context) : base(context) { }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public int Handle()
        {
            Context.Course.Add(new Core.Models.School.Course
            {
                CourseId = this.CourseId,
                Title = this.Title,
                Credits = this.Credits,
                DepartmentId = this.DepartmentId
            });

            return Context.SaveChanges();
        }

        public async Task<int> HandleAsync()
        {
            Context.Course.Add(new Core.Models.School.Course
            {
                CourseId = this.CourseId,
                Title = this.Title,
                Credits = this.Credits,
                DepartmentId = this.DepartmentId
            });

            return await Context.SaveChangesAsync();
        }
    }
}
