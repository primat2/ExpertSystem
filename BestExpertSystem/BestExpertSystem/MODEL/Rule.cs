using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BestExpertSystem.MODEL
{
    public class Rule : INFRASTRUCTURE.IOrdered
    {
        private int order;


        public string name;
        public List<Fact> antecedents;

        public List<Fact> descendants;
        public string explain;


        public int Order {
            get { return order; }
            set { order = value; }
        }

        public Rule(int Order, string Name, List<Fact> Antecedents, List<Fact> Descendants, string Explain)
        {
            order = Order;
            name = Name;
            antecedents = Antecedents;
            descendants = Descendants;
            explain = Explain;
        }

        public Rule(string Name, List<Fact> Antecedents, List<Fact> Descendants, string Explain) {
            order = -1;
            name = Name;
            antecedents = Antecedents;
            descendants = Descendants;
            explain = Explain;
        }


        public override string ToString()
        {
            return $"Rule: {name}";
        }
    }
}
