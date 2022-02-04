namespace BestExpertSystem
{
    partial class ConsultationForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CB_DialogAnswers = new System.Windows.Forms.ComboBox();
            this.BtnDialogResponse = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_Dialog = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(645, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dialog ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Coral;
            this.panel2.Controls.Add(this.CB_DialogAnswers);
            this.panel2.Controls.Add(this.BtnDialogResponse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 321);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(645, 57);
            this.panel2.TabIndex = 1;
            // 
            // CB_DialogAnswers
            // 
            this.CB_DialogAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_DialogAnswers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DialogAnswers.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CB_DialogAnswers.FormattingEnabled = true;
            this.CB_DialogAnswers.IntegralHeight = false;
            this.CB_DialogAnswers.ItemHeight = 49;
            this.CB_DialogAnswers.Location = new System.Drawing.Point(0, 0);
            this.CB_DialogAnswers.MinimumSize = new System.Drawing.Size(50, 0);
            this.CB_DialogAnswers.Name = "CB_DialogAnswers";
            this.CB_DialogAnswers.Size = new System.Drawing.Size(499, 57);
            this.CB_DialogAnswers.TabIndex = 18;
            // 
            // BtnDialogResponse
            // 
            this.BtnDialogResponse.BackColor = System.Drawing.Color.SeaGreen;
            this.BtnDialogResponse.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnDialogResponse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDialogResponse.Font = new System.Drawing.Font("Trebuchet MS", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnDialogResponse.Location = new System.Drawing.Point(499, 0);
            this.BtnDialogResponse.Name = "BtnDialogResponse";
            this.BtnDialogResponse.Size = new System.Drawing.Size(146, 57);
            this.BtnDialogResponse.TabIndex = 15;
            this.BtnDialogResponse.Text = "Ok";
            this.BtnDialogResponse.UseVisualStyleBackColor = false;
            this.BtnDialogResponse.Click += new System.EventHandler(this.BtnDialogResponse_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Cornsilk;
            this.panel3.Controls.Add(this.lb_Dialog);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(645, 221);
            this.panel3.TabIndex = 2;
            // 
            // lb_Dialog
            // 
            this.lb_Dialog.AutoSize = true;
            this.lb_Dialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Dialog.Location = new System.Drawing.Point(0, 0);
            this.lb_Dialog.Name = "lb_Dialog";
            this.lb_Dialog.Padding = new System.Windows.Forms.Padding(10);
            this.lb_Dialog.Size = new System.Drawing.Size(100, 37);
            this.lb_Dialog.TabIndex = 0;
            this.lb_Dialog.Text = "Dialog data";
            // 
            // ConsultationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 378);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultationForm";
            this.Text = "ConsultationForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_Dialog;
        public System.Windows.Forms.ComboBox CB_DialogAnswers;
        public System.Windows.Forms.Button BtnDialogResponse;
    }
}