using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Classes.Services;
using TestApp.Models.DB;

namespace TestApp.Classes
{
    public class SaveDB : DbContext, ISaveDbService
    {
        public DbSet<AnswerEvent> Event { get; set; }
        public DbSet<AnswerAttachment> Attachment { get; set; }

        public SaveDB(IConfiguration config) : base(config.GetConnectionString("answersConnection"))
        {
        }
    }
}
