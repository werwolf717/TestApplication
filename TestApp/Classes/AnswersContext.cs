using System.Data.Entity;
using TestApp.Models.DB;
using Microsoft.Extensions.Configuration;
using TestApp.Classes.Interfaces;

namespace TestApp.Classes
{
    public class AnswersContext : DbContext, ISaveDb
    {
        public DbSet<AnswerEvent> Event { get; set; }
        public DbSet<AnswerAttachment> Attachment { get; set; }
        public AnswersContext(IConfiguration config) : base(config.GetConnectionString("answersConnection")) 
        {
        }

    }
}
