using System.Data.Entity;
using TestApp.Models.DB;

namespace TestApp.Classes.Services
{
    public interface ISaveDbService
    {
        public DbSet<AnswerEvent> Event { get; set; }
        public DbSet<AnswerAttachment> Attachment { get; set; }
    }
}
