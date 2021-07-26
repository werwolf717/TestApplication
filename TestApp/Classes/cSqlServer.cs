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
        public static void WriteEvents(IEvent answer)
        {
            using (TestConn db = new TestConn())
            {
                AnswerEventDD answerDB = new(new Guid(), new Guid(), DateTime.Now, answer.Value, answer.Type, answer.ClientTime);
                db.Answers.Add(answerDB);
                db.SaveChanges();
            }
        }
    }
            
}
