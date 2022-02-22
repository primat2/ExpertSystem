namespace BestExpertSystem.Forms_ES
{
    partial class ExplanationForm
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
            this.tvAppliedRules = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tvAppliedRules
            // 
            this.tvAppliedRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAppliedRules.Location = new System.Drawing.Point(0, 0);
            this.tvAppliedRules.Name = "tvAppliedRules";
            this.tvAppliedRules.Size = new System.Drawing.Size(800, 350);
            this.tvAppliedRules.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 1;
            // 
            // ExplanationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tvAppliedRules);
            this.Controls.Add(this.panel1);
            this.Name = "ExplanationForm";
            this.Text = "Объяснение";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvAppliedRules;
        private System.Windows.Forms.Panel panel1;
    }
}