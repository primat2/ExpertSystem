using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;


namespace BestExpertSystem.UI_LOGICK
{
    public class UI_Variable
    {
        public static UI_Variable instance;
        private MODEL.MemoryComponent memory;
        public Application mainForm;

        public UI_Variable(Application form)
        {
            instance = this;
            mainForm = form;
            memory = MODEL.MemoryComponent.instance;
        }



        private void AddOrUpdate(VariableAddForm myHappyNewForm, MODEL.Variable variableToChange = null, Form Owner = null)
        {
            MODEL.Variable newVariable;
            int order = variableToChange == null ? -1 : variableToChange.Order;

            DialogResult dResult;

            if (Owner != null) dResult = myHappyNewForm.ShowDialog();
            else dResult = myHappyNewForm.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                string name = myHappyNewForm.VariableName.Text;
                string question = myHappyNewForm.VariableQuestion.Text;
                MODEL.VariableType type = (MODEL.VariableType)myHappyNewForm.VarTypeComboBox.SelectedItem;
                MODEL.Domain domain = myHappyNewForm.VarDomainComboBox.SelectedItem as MODEL.Domain;

                newVariable = new MODEL.Variable(order, name, question, domain, type);

                memory.AddOrUpdateVariable(newVariable);
            }
            dResult = DialogResult.None;
        }


        public void ChangeVariable(MODEL.Variable varToChange)
        {
            var myHappyNewForm = new VariableAddForm(memory.GetDomainList(), varToChange, "Editing Variable");
            AddOrUpdate(myHappyNewForm, varToChange);
        }

        public void AddVairable(Form owner = null)
        {
            var myHappyNewForm = new VariableAddForm(memory.GetDomainList(), "Creating new Variable");
            AddOrUpdate(myHappyNewForm, Owner:owner);
        }

    }
}
