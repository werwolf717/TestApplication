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
    public class AnswersContext : DbContext
    {

        public AnswersContext(string connectionString) : base(connectionString) { }
        public DbSet<AnswerEvent> Event { get; set; }
        public DbSet<AnswerAttachment> Attachment { get; set; }

    }
}
