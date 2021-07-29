using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TestApp.Models.DB;
using TestApp.Models.Interfaces;
using TestApp.Models;

namespace TestApp.Classes
{
    public class SqlServer
    {

        public static string connectionString;
        public static void WriteEvents(IEnumerable<IEvent> answer, Guid _answerid)
        {
            using (AnswersContext db = new AnswersContext(connectionString))
            {
                foreach (IEvent _event in answer)
                {
                    db.Event.Add(new(Guid.NewGuid(), _answerid, DateTime.Now, _event));
                    db.SaveChanges();
                }
            }
        }
        public static void WriteAttachment(IAttachment _attachment, Guid _answerid)
        {
            using (AnswersContext db = new AnswersContext(connectionString))
            {
                AnswerAttachment answerDB = new(Guid.NewGuid(), _answerid, DateTime.Now, _attachment);
                db.Attachment.Add(answerDB);
                db.SaveChanges();
            }
        }
    }
            
}
