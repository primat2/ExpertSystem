using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestExpertSystem.MODEL
{
    public class Domain : INFRASTRUCTURE.IOrdered
    {
        private int order;

        public string name;
        public List<VariableValue> values;

        //private int n;


        //public List<VariableValue> Values
        //{
        //    get { return values; }
        //}

        public Domain(int Order, string Name, List<VariableValue> Values)
        {
            order = Order;
            name = Name;
            values = Values;
        }

        public Domain(int Order, string Name, List<string> Values)
        {
            order = Order;
            name = Name;
            values = Values.Select(t => new VariableValue(t)).ToList();
        }

        public Domain(string Name, List<VariableValue> Values)
        {
            order = -1;
            name = Name;
            values = Values;
        }

        public Domain(string Name, List<string> Values)
        {
            order = -1;
            name = Name;
            values = Values.Select(t => new VariableValue(t)).ToList();
        }

        public int Order
        {
            get { return order; }
            set { order = value; }
        }


        public override string ToString()
        {
            return name;
        }
    }
}
