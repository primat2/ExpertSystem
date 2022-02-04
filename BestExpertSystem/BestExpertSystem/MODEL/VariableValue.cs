using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestExpertSystem.MODEL
{
    public class VariableValue
    {
        //Variable varType;
        public string value;

        public string Value
        {
            get { return value; }
        }

        public override string ToString()
        {
            return value;
        }

        public VariableValue(string val)
        {
            value = val;
        }
    }
}
