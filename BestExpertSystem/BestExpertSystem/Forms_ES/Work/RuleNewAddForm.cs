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
    public partial class RuleNewAddForm : Form
    {
        private MODEL.MemoryComponent memory;
        private List<MODEL.Fact> ants;
        private List<MODEL.Fact> descs;

        public MODEL.Rule ruleInConstruction;

        public List<MODEL.Fact> Ants
        {
            get { return ants; }
        }
        public List<MODEL.Fact> Descs
        {
            get { return descs; }
        }

        //public RuleNewAddForm()
        //{
        //    memory = MODEL.MemoryComponent.instance;
        //    InitializeComponent();
        //}

        public RuleNewAddForm(DATA_TYPES.OrderedList<MODEL.Rule> rules, string action = "")
        {
            //BaseConstructor(domains, action);

            //UpdateWidgets();
            memory = MODEL.MemoryComponent.instance;
            InitializeComponent();
            ants = new List<MODEL.Fact>();
            descs = new List<MODEL.Fact>();
        }

        // *******************

        private void UpdateVidgets()
        {
            UpdateListBoxes();
            UpdateConfirmButton();
        }

        private void UpdateConfirmButton()
        {
            bool enabled = true;
            enabled = enabled && listViewAnts.Items.Count > 0;
            enabled = enabled && listViewDescs.Items.Count > 0;
            enabled = enabled && VariableName.Text.Length > 0;
            AddRuleButton.Enabled = enabled;
        }

        private void UpdateListBoxes()
        {
            listViewAnts.Items.Clear();
            for (int i = 0; i < ants.Count; i++)
            {
                listViewAnts.Items.Add(ants[i].ToString());
            }
            listViewDescs.Items.Clear();
            for (int i = 0; i < descs.Count; i++)
            {
                listViewDescs.Items.Add(descs[i].ToString());
            }
        }

        // *******************

        private void AddToLB(List<MODEL.Fact> facts)
        {
            var myHappyNewForm = new AddFactForm();
            myHappyNewForm.FillDataComboBox(memory.variables, myHappyNewForm.VarListCB);

            DialogResult dResult = myHappyNewForm.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                MODEL.Variable type = (MODEL.Variable)myHappyNewForm.VarListCB.SelectedItem;
                MODEL.VariableValue domainValue = myHappyNewForm.DomainListCB.SelectedItem as MODEL.VariableValue;
                MODEL.Fact newFact = new MODEL.Fact(type, domainValue);
                facts.Add(newFact);
            }
            UpdateVidgets();
        }

        private void EditLB(List<MODEL.Fact> facts, ListView listView)
        {
            if (listView.SelectedItems.Count > 0)
            {

                var myHappyNewForm = new AddFactForm();
                myHappyNewForm.FillDataComboBox(memory.variables, myHappyNewForm.VarListCB);
                myHappyNewForm.AddFormButton.Text = "Edit";

                DialogResult dResult = myHappyNewForm.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    MODEL.Variable type = (MODEL.Variable)myHappyNewForm.VarListCB.SelectedItem;
                    MODEL.VariableValue domainValue = myHappyNewForm.DomainListCB.SelectedItem as MODEL.VariableValue;
                    MODEL.Fact newFact = new MODEL.Fact(type, domainValue);
                    int idx = listView.SelectedItems[0].Index;
                    facts[idx] = newFact;
                }
            }
            UpdateVidgets();
        }

        private void DeleteFromLB(List<MODEL.Fact> facts, ListView listView)
        {
            if (listView.SelectedItems.Count > 0)
            {
                int idx = listView.SelectedItems[0].Index;
                facts.RemoveAt(idx);
            }
            UpdateVidgets();
        }

        // *******************
        // *** ANTECENDANT ***
        // *******************

        private void ButAddAnt_Click(object sender, EventArgs e)
        {
            AddToLB(ants);
        }

        private void ButEditAnt_Click(object sender, EventArgs e)
        {
            EditLB(ants, listViewAnts);
        }

        private void ButDeleteAdd_Click(object sender, EventArgs e)
        {
            DeleteFromLB(ants, listViewAnts);
        }

        // ******************
        // *** DESCENDANT ***
        // ******************

        private void ButAddDesc_Click(object sender, EventArgs e)
        {
            AddToLB(descs);
        }

        private void ButEditDesc_Click(object sender, EventArgs e)
        {
            EditLB(descs, listViewDescs);
        }

        private void ButDeleteDesc_Click(object sender, EventArgs e)
        {
            DeleteFromLB(descs, listViewDescs);
        }



        // *** THE REST ***

        private void AddFact()
        {

        }

        private void RuleNewAddForm_Load(object sender, EventArgs e)
        {

        }

        // Add Rule button
        private void AddVariableButton_Click(object sender, EventArgs e)
        {

        }

        private void VariableName_TextChanged(object sender, EventArgs e)
        {
            UpdateConfirmButton();
        }
    }
}
