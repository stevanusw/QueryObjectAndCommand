using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Queries.Course
{
    public class GetCourseByIdQuery
    {
        public GetCourseByIdQuery(int id, bool includeData)
        {
            Id = id;
            IncludeData = includeData;
        }

        public int Id { get; set; }
        public bool IncludeData { get; set; }
    }
}
