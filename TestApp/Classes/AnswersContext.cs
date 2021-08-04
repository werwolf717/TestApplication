using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TestApp.Models.DB;
using TestApp.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using TestApp.Classes.Services;

namespace TestApp.Classes
{
    public class AnswersContext : DbContext, ISaveDbService
    {
        public DbSet<AnswerEvent> Event { get; set; }
        public DbSet<AnswerAttachment> Attachment { get; set; }
        public AnswersContext(IConfiguration config) : base(config.GetConnectionString("answersConnection")) 
        {
        }

    }
}
