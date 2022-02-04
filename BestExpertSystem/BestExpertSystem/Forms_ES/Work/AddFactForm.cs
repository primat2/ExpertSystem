using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestExpertSystem
{
    public partial class AddFactForm : Form
    {
        private bool canConfirm;

        public AddFactForm()
        {
            InitializeComponent();
        }


        public void FillDataComboBox<T>(DATA_TYPES.OrderedList<T> data, ComboBox cb)
    where T : INFRASTRUCTURE.IOrdered
        {
            cb.Items.Clear();
            foreach (var datum in data)
            {
                cb.Items.Add(datum);
            }
            if (VarListCB.Text.Length > 0)
            {
                cb.SelectedItem = cb.Items[0];
            }
        }

        public void FillDataComboBox(List<MODEL.VariableValue> data, ComboBox cb)
        {
            cb.Items.Clear();
            foreach (var datum in data)
            {
                cb.Items.Add(datum);
            }
            if (VarListCB.Text.Length > 0)
            {
                cb.SelectedItem = cb.Items[0];
            }
        }


        private void UpdateVidgets() {
            bool enabled = true;
            enabled = enabled && VarListCB.SelectedItem != null;
            enabled = enabled && DomainListCB.SelectedItem != null;
            AddFormButton.Enabled = enabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UI_LOGICK.UI_Variable.instance.AddVairable(this);

            int x = 55;
            int y = x + 6;
        }

        private void AddFactForm_Load(object sender, EventArgs e)
        {

        }

        // Add fact button click
        private void AddFormButton_Click(object sender, EventArgs e)
        {
            //MODEL.Fact newFact = new MODEL.Fact();

            //string name = myHappyNewForm.VariableName.Text;
            //string question = myHappyNewForm.VariableQuestion.Text;
            //MODEL.VariableType type = (MODEL.VariableType)myHappyNewForm.VarTypeComboBox.SelectedItem;
            //MODEL.Domain domain = myHappyNewForm.VarDomainComboBox.SelectedItem as MODEL.Domain;

            //newVariable = new MODEL.Variable(order, name, question, domain, type);

            //memory.AddOrUpdateVariable(newVariable);
        }

        private void VarListCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVidgets();
            MODEL.Variable selectedVar = (MODEL.Variable)VarListCB.SelectedItem;
            FillDataComboBox(selectedVar.domain.values, DomainListCB);
            //DomainListCB.Items
        }

        private void DomainListCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVidgets();
        }
    }
}
