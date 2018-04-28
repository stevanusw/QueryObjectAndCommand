using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Queries.Course
{
    public class GetAllCoursesQuery
    {
        public GetAllCoursesQuery(bool includeData)
        {
            IncludeData = includeData;
        }

        public bool IncludeData { get; set; }
    }
}
