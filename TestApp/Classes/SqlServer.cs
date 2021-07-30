using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TestApp.Models.DB;
using TestApp.Models.Interfaces;
using TestApp.Models;
using Microsoft.Extensions.Configuration;

namespace TestApp.Classes
{
    public class SqlServer
    {
        public static async Task WriteEventsAsync(IEnumerable<IEvent> answer, Guid _answerid, IConfiguration config)
        {
            try
            {
                using (AnswersContext db = new AnswersContext(config.GetConnectionString("answersConnection")))
                {
                    foreach (IEvent _event in answer)
                    {
                        db.Event.Add(new(Guid.NewGuid(), _answerid, DateTime.Now, _event));
                    }
                    await db.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("SQL Error", ex.InnerException);
            }
        }
        public static void WriteAttachment(IAttachment _attachment, Guid _answerid, IConfiguration config)
        {
            try
            {
                using (AnswersContext db = new AnswersContext(config.GetConnectionString("answersConnection")))
                {
                    AnswerAttachment answerDB = new(Guid.NewGuid(), _answerid, DateTime.Now, _attachment);
                    db.Attachment.Add(answerDB);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("SQL Error", ex.InnerException);
            }
        }
    }
            
}
