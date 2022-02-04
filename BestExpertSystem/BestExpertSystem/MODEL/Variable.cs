using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestExpertSystem.MODEL
{
    public enum VariableType {
        Requested,
        Deducible,
        RequestedDeducible
    };

    public class Variable : INFRASTRUCTURE.IOrdered
    {
        private int order;
        public string name;

        public string question;
        public Domain domain;
        public VariableType variableType;

        public int Order {
            get { return order; }
            set { order = value; }
        }


        public Variable(int Order, string Name, string Question, Domain Domain, VariableType VarType)
        {
            order = Order;
            name = Name;
            question = Question;
            domain = Domain;
            variableType = VarType;
        }

        public Variable(string Name, string Question, Domain Domain, VariableType VarType)
        {
            order = -1;
            name = Name;
            question = Question;
            domain = Domain;
            variableType = VarType;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
