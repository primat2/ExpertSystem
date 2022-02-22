namespace BestExpertSystem.Forms_ES.TMP
{
    partial class ChooseEsName
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnChooseNameConfirm = new System.Windows.Forms.Button();
            this.TbEsName = new System.Windows.Forms.TextBox();
            this.lblWarn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(77, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите название новой ЭС";
            // 
            // btnChooseNameConfirm
            // 
            this.btnChooseNameConfirm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnChooseNameConfirm.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnChooseNameConfirm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnChooseNameConfirm.Enabled = false;
            this.btnChooseNameConfirm.Location = new System.Drawing.Point(0, 155);
            this.btnChooseNameConfirm.Name = "btnChooseNameConfirm";
            this.btnChooseNameConfirm.Size = new System.Drawing.Size(439, 50);
            this.btnChooseNameConfirm.TabIndex = 2;
            this.btnChooseNameConfirm.Text = "Создать";
            this.btnChooseNameConfirm.UseVisualStyleBackColor = false;
            // 
            // TbEsName
            // 
            this.TbEsName.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbEsName.Location = new System.Drawing.Point(17, 73);
            this.TbEsName.Name = "TbEsName";
            this.TbEsName.Size = new System.Drawing.Size(410, 27);
            this.TbEsName.TabIndex = 6;
            this.TbEsName.TextChanged += new System.EventHandler(this.TbEsName_TextChanged);
            // 
            // lblWarn
            // 
            this.lblWarn.Location = new System.Drawing.Point(17, 103);
            this.lblWarn.Name = "lblWarn";
            this.lblWarn.Size = new System.Drawing.Size(410, 23);
            this.lblWarn.TabIndex = 7;
            // 
            // ChooseEsName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 205);
            this.Controls.Add(this.lblWarn);
            this.Controls.Add(this.TbEsName);
            this.Controls.Add(this.btnChooseNameConfirm);
            this.Controls.Add(this.label1);
            this.Name = "ChooseEsName";
            this.Text = "Выбор названия";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChooseNameConfirm;
        public System.Windows.Forms.TextBox TbEsName;
        private System.Windows.Forms.Label lblWarn;
    }
}