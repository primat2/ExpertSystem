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
    public partial class VariableAddForm : Form
    {

        bool domainValueSelected = false;

        private void BaseConstructor(DATA_TYPES.OrderedList<MODEL.Domain> domains, string action = "")
        {
            InitializeComponent();
            FillDomainComboBox(domains);
            VariableHeader.Text = action;

            VarTypeComboBox.Items.Clear();
            VarTypeComboBox.Items.Add(MODEL.VariableType.Deducible);
            VarTypeComboBox.Items.Add(MODEL.VariableType.Requested);
            VarTypeComboBox.Items.Add(MODEL.VariableType.RequestedDeducible);
            VarTypeComboBox.SelectedItem = VarTypeComboBox.Items[0];
        }

        public VariableAddForm(DATA_TYPES.OrderedList<MODEL.Domain> domains, string action = "")
        {
            BaseConstructor(domains, action);
            
            //VarDomainComboBox
           

            UpdateWidgets();
        }

        public VariableAddForm(DATA_TYPES.OrderedList<MODEL.Domain> domains, MODEL.Variable varToChange, string action = "")
        {
            BaseConstructor(domains, action);
            FillDomainComboBox(domains);
            VarDomainComboBox.SelectedItem = varToChange.domain;
            VarTypeComboBox.SelectedItem = varToChange.variableType;
            VariableName.Text = varToChange.name;
            VariableQuestion.Text = varToChange.question;

            UpdateWidgets();
        }


        private void UpdateWidgets()
        {
            UpdateChangeDomainButton();
            UpdateVariableAddButton();
            UpdateListViewDomainValues();
        }


        private void UpdateChangeDomainButton()
        {
            MODEL.Domain selectedDomain = VarDomainComboBox.SelectedItem as MODEL.Domain;
            domainValueSelected = selectedDomain != null;

            ButChangeSelectedDomain.Enabled = domainValueSelected;
        }

        private void UpdateVariableAddButton()
        {
            bool len = VariableName.Text.Length > 0;
            bool b1 = VarDomainComboBox.SelectedItem != null;
            bool b2 = VarTypeComboBox.SelectedItem != null;

            AddVariableButton.Enabled = len && b1 && b2;

        }

        private void UpdateListViewDomainValues()
        {
            MODEL.Domain selectedDomain = VarDomainComboBox.SelectedItem as MODEL.Domain;
            domainValueSelected = selectedDomain != null;
            if (domainValueSelected)
            {
                UI_LOGICK.Util.UpdateListView(DomainListView, selectedDomain.values);
            }
        }


        public void FillDomainComboBox(DATA_TYPES.OrderedList<MODEL.Domain> domains)
        {
            VarDomainComboBox.Items.Clear();
            foreach (var domain in domains)
            {
                VarDomainComboBox.Items.Add(domain);
            }
            if (VarDomainComboBox.Text.Length > 0)
            {
                VarDomainComboBox.SelectedItem = VarDomainComboBox.Items[0];
            }
        }


        private void AddContextDomain_Click(object sender, EventArgs e)
        {
            Application.instance.UI_DomainWorker.AddDomain();
            FillDomainComboBox(MODEL.MemoryComponent.instance.GetDomainList());
            //UI_LOGICK.Util.UpdateListView(DomainListView, selectedDomain.values);
        }

        private void ButChangeSelectedDomain_Click(object sender, EventArgs e)
        {

            MODEL.Domain selectedDomain = VarDomainComboBox.SelectedItem as MODEL.Domain;
            if (selectedDomain != null)
            {
                Application.instance.UI_DomainWorker.ChangeDomain(selectedDomain);
            }

            UpdateWidgets();
        }

        private void AddVariableButton_Click(object sender, EventArgs e)
        {
            //var values = new List<string>() { Value.Text };
            //UI_LOGICK.Util.AddToListBox(DomainListView, values);
        }

        private void VarDomainComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateWidgets();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VariableQuestion_TextChanged(object sender, EventArgs e)
        {
            UpdateWidgets();
        }

        private void VarDomainComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWidgets();
        }

        private void VarTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWidgets();
        }

        private void VariableAddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
