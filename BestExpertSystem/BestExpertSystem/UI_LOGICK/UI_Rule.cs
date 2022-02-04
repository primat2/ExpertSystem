using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace BestExpertSystem.UI_LOGICK
{
    public class UI_Rule
    {
        private MODEL.MemoryComponent memory;
        public Application mainForm;

        public UI_Rule(Application form)
        {
            mainForm = form;
            memory = MODEL.MemoryComponent.instance;
        }



        private void AddOrUpdate(RuleNewAddForm myHappyNewForm, MODEL.Rule ruleToChange = null)
        {
            MODEL.Rule newRule;
            int order = ruleToChange == null ? -1 : ruleToChange.Order;

            DialogResult dResult = myHappyNewForm.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                string name = myHappyNewForm.VariableName.Text;
                string explanation = myHappyNewForm.RuleExplaination.Text;

                List<MODEL.Fact> Antecedents = myHappyNewForm.Ants;
                List<MODEL.Fact> Descendants = myHappyNewForm.Descs;


                newRule = new MODEL.Rule(order, name, Antecedents, Descendants, explanation);
                memory.AddOrUpdateRule(newRule);

            }
        }


        public void ChangeRule(MODEL.Rule varToChange)
        {
            //var myHappyNewForm = new VariableAddForm(memory.GetDomainList(), varToChange, "Editing Variable");
            //AddOrUpdate(myHappyNewForm, varToChange);
        }

        public void AddRule()
        {
            var myHappyNewForm = new RuleNewAddForm(memory.GetRuleList(), "Creating new Rule");
            AddOrUpdate(myHappyNewForm);
        }
    }
}
