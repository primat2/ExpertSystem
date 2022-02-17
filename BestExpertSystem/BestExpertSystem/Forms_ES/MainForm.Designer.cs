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
            this.lvExpertSystems = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditES = new System.Windows.Forms.Button();
            this.btnAuthenticate = new System.Windows.Forms.Button();
            this.DoaminLine_1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAuth = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelAuthFull = new System.Windows.Forms.Panel();
            this.lblHello = new System.Windows.Forms.Label();
            this.btnConsultation = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.DoaminLine_1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelAuth.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelAuthFull.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCreateES
            // 
            this.btCreateES.BackColor = System.Drawing.Color.SeaGreen;
            this.btCreateES.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btCreateES.Location = new System.Drawing.Point(483, 347);
            this.btCreateES.Name = "btCreateES";
            this.btCreateES.Size = new System.Drawing.Size(411, 52);
            this.btCreateES.TabIndex = 5;
            this.btCreateES.Text = "Создать новую ЭС";
            this.btCreateES.UseVisualStyleBackColor = false;
            this.btCreateES.Click += new System.EventHandler(this.btCreateES_Click);
            // 
            // lvExpertSystems
            // 
            this.lvExpertSystems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvExpertSystems.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvExpertSystems.FullRowSelect = true;
            this.lvExpertSystems.HideSelection = false;
            this.lvExpertSystems.Location = new System.Drawing.Point(0, 0);
            this.lvExpertSystems.Name = "lvExpertSystems";
            this.lvExpertSystems.Size = new System.Drawing.Size(483, 399);
            this.lvExpertSystems.TabIndex = 1;
            this.lvExpertSystems.UseCompatibleStateImageBehavior = false;
            this.lvExpertSystems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Экспертная система";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Владелец";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 160;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 51);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(894, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Лаборатоная работа № 4. Выполнено студентом Гавшином и студентом Петровым\r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditES
            // 
            this.btnEditES.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnEditES.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEditES.Location = new System.Drawing.Point(483, 295);
            this.btnEditES.Name = "btnEditES";
            this.btnEditES.Size = new System.Drawing.Size(411, 52);
            this.btnEditES.TabIndex = 4;
            this.btnEditES.Text = "Редактировать ЭС";
            this.btnEditES.UseVisualStyleBackColor = false;
            this.btnEditES.Click += new System.EventHandler(this.btnEditES_Click);
            // 
            // btnAuthenticate
            // 
            this.btnAuthenticate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAuthenticate.Enabled = false;
            this.btnAuthenticate.Location = new System.Drawing.Point(0, 97);
            this.btnAuthenticate.Name = "btnAuthenticate";
            this.btnAuthenticate.Size = new System.Drawing.Size(411, 32);
            this.btnAuthenticate.TabIndex = 3;
            this.btnAuthenticate.Text = "Представить себя";
            this.btnAuthenticate.UseVisualStyleBackColor = true;
            this.btnAuthenticate.Click += new System.EventHandler(this.btnAuthenticate_Click);
            // 
            // DoaminLine_1
            // 
            this.DoaminLine_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DoaminLine_1.Controls.Add(this.panel4);
            this.DoaminLine_1.Controls.Add(this.panel3);
            this.DoaminLine_1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DoaminLine_1.Location = new System.Drawing.Point(0, 52);
            this.DoaminLine_1.Name = "DoaminLine_1";
            this.DoaminLine_1.Size = new System.Drawing.Size(411, 45);
            this.DoaminLine_1.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.tbPassword);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(217, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 45);
            this.panel4.TabIndex = 1;
            // 
            // tbPassword
            // 
            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassword.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(0, 0);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(192, 53);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 45);
            this.panel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 43);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAuth
            // 
            this.panelAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelAuth.Controls.Add(this.panel6);
            this.panelAuth.Controls.Add(this.panel7);
            this.panelAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAuth.Location = new System.Drawing.Point(0, 0);
            this.panelAuth.Name = "panelAuth";
            this.panelAuth.Size = new System.Drawing.Size(411, 52);
            this.panelAuth.TabIndex = 19;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tbLogin);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(217, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(194, 52);
            this.panel6.TabIndex = 1;
            // 
            // tbLogin
            // 
            this.tbLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLogin.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLogin.Location = new System.Drawing.Point(0, 0);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(192, 53);
            this.tbLogin.TabIndex = 1;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(217, 52);
            this.panel7.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 50);
            this.label3.TabIndex = 4;
            this.label3.Text = "Логин";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAuthFull
            // 
            this.panelAuthFull.BackColor = System.Drawing.Color.CadetBlue;
            this.panelAuthFull.Controls.Add(this.panelAuth);
            this.panelAuthFull.Controls.Add(this.DoaminLine_1);
            this.panelAuthFull.Controls.Add(this.btnAuthenticate);
            this.panelAuthFull.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAuthFull.Location = new System.Drawing.Point(483, 0);
            this.panelAuthFull.Name = "panelAuthFull";
            this.panelAuthFull.Size = new System.Drawing.Size(411, 129);
            this.panelAuthFull.TabIndex = 3;
            // 
            // lblHello
            // 
            this.lblHello.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHello.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHello.Location = new System.Drawing.Point(483, 129);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(411, 17);
            this.lblHello.TabIndex = 20;
            this.lblHello.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConsultation
            // 
            this.btnConsultation.BackColor = System.Drawing.Color.YellowGreen;
            this.btnConsultation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultation.Location = new System.Drawing.Point(483, 146);
            this.btnConsultation.Name = "btnConsultation";
            this.btnConsultation.Size = new System.Drawing.Size(411, 56);
            this.btnConsultation.TabIndex = 21;
            this.btnConsultation.Text = "Проконсультироваться";
            this.btnConsultation.UseVisualStyleBackColor = false;
            this.btnConsultation.Click += new System.EventHandler(this.btnConsultation_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 450);
            this.Controls.Add(this.btnConsultation);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.btnEditES);
            this.Controls.Add(this.btCreateES);
            this.Controls.Add(this.panelAuthFull);
            this.Controls.Add(this.lvExpertSystems);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Главное окно";
            this.panel1.ResumeLayout(false);
            this.DoaminLine_1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelAuth.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panelAuthFull.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCreateES;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvExpertSystems;
        private System.Windows.Forms.Button btnEditES;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAuthenticate;
        private System.Windows.Forms.Panel DoaminLine_1;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelAuth;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelAuthFull;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.Button btnConsultation;
    }
}