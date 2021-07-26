using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TestApp.Models.DB;
using TestApp.Models.Interfaces;

namespace TestApp.Classes
{
    public class TestConn : DbContext
    {

        public TestConn() : base(
                @"Data Source=(localdb)\MSSQLLocalDb;" +
                "Initial Catalog=Answers;" +
                "Integrated Security=SSPI;")
        { }

        public DbSet<AnswerEventDD> Answers { get; set; }

    }
}
