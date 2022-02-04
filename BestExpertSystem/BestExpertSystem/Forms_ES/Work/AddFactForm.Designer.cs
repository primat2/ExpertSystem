namespace BestExpertSystem
{
    partial class AddFactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VarListCB = new System.Windows.Forms.ComboBox();
            this.AddFormButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DomainListCB = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VarListCB
            // 
            this.VarListCB.Dock = System.Windows.Forms.DockStyle.Left;
            this.VarListCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VarListCB.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VarListCB.FormattingEnabled = true;
            this.VarListCB.IntegralHeight = false;
            this.VarListCB.ItemHeight = 49;
            this.VarListCB.Location = new System.Drawing.Point(0, 0);
            this.VarListCB.MinimumSize = new System.Drawing.Size(50, 0);
            this.VarListCB.Name = "VarListCB";
            this.VarListCB.Size = new System.Drawing.Size(585, 57);
            this.VarListCB.TabIndex = 8;
            this.VarListCB.SelectedIndexChanged += new System.EventHandler(this.VarListCB_SelectedIndexChanged);
            // 
            // AddFormButton
            // 
            this.AddFormButton.BackColor = System.Drawing.Color.SeaGreen;
            this.AddFormButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddFormButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddFormButton.Enabled = false;
            this.AddFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFormButton.Font = new System.Drawing.Font("Trebuchet MS", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddFormButton.Location = new System.Drawing.Point(0, 248);
            this.AddFormButton.Name = "AddFormButton";
            this.AddFormButton.Size = new System.Drawing.Size(660, 44);
            this.AddFormButton.TabIndex = 14;
            this.AddFormButton.Text = "ADD";
            this.AddFormButton.UseVisualStyleBackColor = false;
            this.AddFormButton.Click += new System.EventHandler(this.AddFormButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.VarListCB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 56);
            this.panel1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(585, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 56);
            this.button1.TabIndex = 16;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(0, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(660, 135);
            this.label4.TabIndex = 16;
            this.label4.Text = "==";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DomainListCB
            // 
            this.DomainListCB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DomainListCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DomainListCB.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DomainListCB.FormattingEnabled = true;
            this.DomainListCB.IntegralHeight = false;
            this.DomainListCB.ItemHeight = 49;
            this.DomainListCB.Location = new System.Drawing.Point(0, 191);
            this.DomainListCB.MinimumSize = new System.Drawing.Size(50, 0);
            this.DomainListCB.Name = "DomainListCB";
            this.DomainListCB.Size = new System.Drawing.Size(660, 57);
            this.DomainListCB.TabIndex = 17;
            this.DomainListCB.SelectedIndexChanged += new System.EventHandler(this.DomainListCB_SelectedIndexChanged);
            // 
            // AddFactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 292);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DomainListCB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AddFormButton);
            this.Name = "AddFactForm";
            this.Text = "Adding new rule";
            this.Load += new System.EventHandler(this.AddFactForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox VarListCB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox DomainListCB;
        public System.Windows.Forms.Button AddFormButton;
    }
}