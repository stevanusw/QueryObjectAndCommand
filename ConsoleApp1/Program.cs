using System;
using System.IO;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Core.Commands.Course;
using Core.Queries.Course;
using Infrastructure.Commands.Course;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Environment.GetEnvironmentVariable("MODE") != "MIGRATION")
            {
                var appConfigBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

                var appConfig = appConfigBuilder.Build();

                var optionsBuilder = new DbContextOptionsBuilder();
                optionsBuilder.UseSqlServer(appConfig.GetConnectionString("School"));

                var context = new SchoolDbContext(optionsBuilder.Options);

                // Testing IQueryHandler.
                Console.WriteLine("Testing IQueryHandler.");

                ICourseQueryRepository courseQueryRepo = new CourseQueryRepository(context);
                var courses = courseQueryRepo.GetAsync(new Core.Queries.Course.GetAllCoursesQuery(true)).Result;

                Console.WriteLine($"Number of courses: {courses.Count()}");
                foreach (var course in courses)
                {
                    Console.WriteLine($"Average marks for subject {course.Title}: {(course.StudentGrade.Sum(g => g.Grade) / (course.StudentGrade.Count() == 0 ? 1 : course.StudentGrade.Count()))}");
                }

                var calculus = courseQueryRepo.GetSingleAsync(new Core.Queries.Course.GetCourseByIdQuery(1045, true)).Result;
                Console.WriteLine($"Subject {calculus.Title} belongs to department {calculus.Department.Name}.");

                // Testing IQueryCommandHandler.
                Console.WriteLine();
                Console.WriteLine("Testing IQueryCommandHandler.");

                ICourseCommandRepository courseCommandRepo = new CourseCommandRepository();
                courses = courseCommandRepo.GetAsync(new Infrastructure.Commands.Course.GetAllCoursesQuery(context)
                {
                    IncludeData = true
                }).Result;

                Console.WriteLine($"Number of courses: {courses.Count()}");
                foreach (var course in courses)
                {
                    Console.WriteLine($"Average marks for subject {course.Title}: {(course.StudentGrade.Sum(g => g.Grade) / (course.StudentGrade.Count() == 0 ? 1 : course.StudentGrade.Count()))}");
                }

                calculus = courseCommandRepo.GetSingleAsync(new Infrastructure.Commands.Course.GetCourseByIdQuery(context)
                {
                    IncludeData = true,
                    Id = 1045
                }).Result;
                Console.WriteLine($"Subject {calculus.Title} belongs to department {calculus.Department.Name}.");

                // Testing ICommandHandler.
                Console.WriteLine();
                Console.WriteLine("Testing ICommandHandler.");

                courseCommandRepo.ExecuteAsync(new CreateCourseCommand(context)
                {
                    CourseId = 5045,
                    Title = "Test",
                    Credits = 4,
                    DepartmentId = 7
                }).Wait();

                courseCommandRepo.ExecuteAsync(new UpdateCourseCommand(context)
                {
                    CourseId = 5045,
                    Title = "Test2",
                    Credits = 4,
                    DepartmentId = 7
                }).Wait();

                courseCommandRepo.ExecuteAsync(new DeleteCourseCommand(context)
                {
                    CourseId = 5045
                }).Wait();

                Console.WriteLine("Done.");
                Console.Read();
            }
        }
    }
}
