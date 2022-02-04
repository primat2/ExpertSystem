using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestExpertSystem.MODEL
{
    public class Fact
    {
        private int order;
        Variable varType;
        VariableValue varValue;


        public Variable Variable
        {
            get => varType;
            set
            {
                varValue = null;
                varType = value;
                //OnPropertyChanged(nameof(Variable));
            }
        }
        public VariableValue DomainValue
        {
            get => varValue;
            set
            {
                varValue = value;
                //OnPropertyChanged(nameof(DomainValue));
            }
        }

        public int Order
        {
            get { return order; }
            set { order = value; }
        }

        public Fact(Variable VarType, VariableValue VarValue)
        {
            order = -1;
            varType = VarType;
            varValue = VarValue;
        }

        public Fact(int Order, Variable VarType, VariableValue VarValue)
        {
            order = Order;
            varType = VarType;
            varValue = VarValue;
        }

        public override string ToString()
        {
            return $"{varType.name} == {varValue}";
        }
    }
}
