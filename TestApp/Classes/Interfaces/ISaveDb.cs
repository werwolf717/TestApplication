using System.Data.Entity;
using TestApp.Models.DB;

namespace TestApp.Classes.Interfaces
{
    public interface ISaveDb
    {
        public DbSet<AnswerEvent> Event { get; set; }
        public DbSet<AnswerAttachment> Attachment { get; set; }
    }
}
