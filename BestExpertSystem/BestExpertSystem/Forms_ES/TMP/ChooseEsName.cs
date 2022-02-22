using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestExpertSystem.Forms_ES.TMP
{
    public partial class ChooseEsName : Form
    {
        public ChooseEsName()
        {
            InitializeComponent();
        }

        private void TbEsName_TextChanged(object sender, EventArgs e)
        {
            if (TbEsName.Text.Length >= 3)
            {
                btnChooseNameConfirm.Enabled = true;
                lblWarn.Text = "";
            }
            else
            {
                lblWarn.Text = "Не короче трёх символов";
            }
        }
    }
}
