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
    public partial class RuleAddForm : Form
    {

        bool canConfirm;

        public RuleAddForm()
        {
            InitializeComponent();
        }

        // Description
        private void textBox2_TextChanged(object sender, EventArgs e) { }


        private void button1_Click(object sender, EventArgs e)
        {
            // Form1.instance.
        }

        private bool CheckNotEmpty()
        {
            return textBoxName.Text != "" && textBoxContent.Text != "";
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            canConfirm = CheckNotEmpty();
            BlockConfirm();
        }

        private void textBoxContent_TextChanged(object sender, EventArgs e)
        {
            canConfirm = CheckNotEmpty();
            BlockConfirm();
        }

        void BlockConfirm()
        {
            buttonConfirm.Visible = canConfirm;
        }
    }
}
