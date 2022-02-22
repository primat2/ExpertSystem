using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestExpertSystem
{
    public class TransferObj
    {
        public int ES_id { get; set; }
        public string GoalVar { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public TransferObj(int es_id = -1, string goalVar = "", string question = "", string answer = "")
        {
            ES_id = es_id;
            GoalVar = goalVar;
            Question = question;
            Answer = answer;
        }
    }
}
