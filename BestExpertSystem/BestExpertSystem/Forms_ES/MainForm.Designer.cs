namespace BestExpertSystem.Forms_ES
{
    partial class MainForm
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
            this.btCreateES = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btCreateES
            // 
            this.btCreateES.Location = new System.Drawing.Point(419, 215);
            this.btCreateES.Name = "btCreateES";
            this.btCreateES.Size = new System.Drawing.Size(149, 52);
            this.btCreateES.TabIndex = 0;
            this.btCreateES.Text = "Создать ЭС";
            this.btCreateES.UseVisualStyleBackColor = true;
            this.btCreateES.Click += new System.EventHandler(this.btCreateES_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btCreateES);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCreateES;
    }
}