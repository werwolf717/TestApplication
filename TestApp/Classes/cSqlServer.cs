using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TestApp.Models.DB;
using TestApp.Models.Interfaces;

namespace TestApp.Classes
{
    public class cSqlServer
    {

        public static string connectionString;
        public static void WriteEvents(IEvent answer, Guid _answerid)
        {
            using (AnswersContext db = new AnswersContext(connectionString))
            {
                AnswerEvent answerDB = new(Guid.NewGuid(), _answerid, DateTime.Now, answer);
                db.Event.Add(answerDB);
                db.SaveChanges();
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
