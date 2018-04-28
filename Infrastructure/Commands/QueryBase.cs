using System;
using System.Collections.Generic;
using System.Text;

using Infrastructure.Data;

namespace Infrastructure.Commands
{
    public class QueryBase
    {
        public QueryBase(SchoolDbContext context)
        {
            Context = context;
        }

        protected SchoolDbContext Context { get; private set; }
    }
}
