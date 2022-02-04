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
    public partial class DomainAddForm : Form
    {
        //private 
        bool canAddValue = false;
        bool canSaveDomain = false;


        public DomainAddForm()
        {
            InitializeComponent();
            //DomainListView.Width = 50;
        }

        public DomainAddForm(MODEL.Domain domain)
        {
            InitializeComponent();
            DomainName.Text = domain.name;

            //DomainListView.Items.Add(domain.values[0]);
            foreach (var value in domain.values)
            {
                DomainListView.Items.Add(value.Value);
            }
            //DomainListView.Width = 50;
        }


        private void UpdateWidgets()
        {
            UpdateAddValueButton();
            UdpadeSaveButton();
        }

        private void UdpadeSaveButton()
        {
            SaveDomain.Enabled = DomainListView.Items.Count > 0;
        }
        private void UpdateAddValueButton()
        {
            bool isEnabled = true;
            isEnabled = isEnabled && Value.Text.Length > 0;
            isEnabled = isEnabled && DomainName.Text.Length > 0;

            AddValue.Enabled = isEnabled;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddValue_Click(object sender, EventArgs e)
        {
            var values = new List<string>() { Value.Text };
            UI_LOGICK.Util.AddToListBox(DomainListView, values);

            UdpadeSaveButton();
            DomainListView.SelectedItems.Clear();
        }


        private void SaveDomain_Click(object sender, EventArgs e)
        {

        }



        private void DomainListView_ItemActivate(object sender, EventArgs e)
        {
            //var x = DomainListView.SelectedItems[0];
            //EditValue.Enabled = true;
        }

        private void DomainListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DomainListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EditValue.Enabled = DomainListView.SelectedItems.Count != 0;
            RemoveValue.Enabled = DomainListView.SelectedItems.Count != 0;
            if (DomainListView.SelectedItems.Count != 0)
            {
                Value.Text = DomainListView.SelectedItems[0].Text;
            }
            else
            {
                Value.Text = "";
            }
        }

        private void DomainListView_Leave(object sender, EventArgs e)
        {
            //EditValue.Enabled = false;
            
        }

        private void EditValue_Click(object sender, EventArgs e)
        {
            ListViewItem item = DomainListView.SelectedItems[0];
            item.Text = Value.Text;
            DomainListView.SelectedItems.Clear();
        }

        private void RemoveValue_Click(object sender, EventArgs e)
        {
            ListViewItem item = DomainListView.SelectedItems[0];
            item.Remove();
            DomainListView.SelectedItems.Clear(); 
        }

        private void Value_TextChanged(object sender, EventArgs e)
        {
            UpdateWidgets();
        }

        private void DomainAddForm_Resize(object sender, EventArgs e)
        {
            DomainListView.Columns[0].Width = DomainListView.Width - 5;
        }

        private void DomainAddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
