using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestExpertSystem.Forms_ES
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btCreateES_Click(object sender, EventArgs e)
        {
            var createES_form = new Application();
            DialogResult dResult = createES_form.ShowDialog();
        }
    }
}
