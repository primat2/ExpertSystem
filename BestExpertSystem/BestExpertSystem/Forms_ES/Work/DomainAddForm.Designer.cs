namespace BestExpertSystem
{
    partial class DomainAddForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Value = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AddValue = new System.Windows.Forms.Button();
            this.EditValue = new System.Windows.Forms.Button();
            this.RemoveValue = new System.Windows.Forms.Button();
            this.DomainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SaveDomain = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EnterDomainPanel = new System.Windows.Forms.Panel();
            this.PanelLine_1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DomainName = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.PanelLine_2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panelLine = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.EnterDomainPanel.SuspendLayout();
            this.PanelLine_1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.PanelLine_2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panelLine.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(754, 70);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adding Domain";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 50);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name Of Domain";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 108);
            this.label3.TabIndex = 3;
            this.label3.Text = "Values";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Value
            // 
            this.Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Value.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value.Location = new System.Drawing.Point(0, 0);
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(514, 53);
            this.Value.TabIndex = 5;
            this.Value.TextChanged += new System.EventHandler(this.Value_TextChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 51);
            this.label4.TabIndex = 6;
            this.label4.Text = "New value";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddValue
            // 
            this.AddValue.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.AddValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddValue.Enabled = false;
            this.AddValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddValue.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddValue.Location = new System.Drawing.Point(0, 0);
            this.AddValue.Name = "AddValue";
            this.AddValue.Size = new System.Drawing.Size(240, 63);
            this.AddValue.TabIndex = 7;
            this.AddValue.Text = "ADD";
            this.AddValue.UseVisualStyleBackColor = false;
            this.AddValue.Click += new System.EventHandler(this.AddValue_Click);
            // 
            // EditValue
            // 
            this.EditValue.BackColor = System.Drawing.Color.DarkKhaki;
            this.EditValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditValue.Enabled = false;
            this.EditValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditValue.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditValue.Location = new System.Drawing.Point(0, 0);
            this.EditValue.Name = "EditValue";
            this.EditValue.Size = new System.Drawing.Size(754, 63);
            this.EditValue.TabIndex = 8;
            this.EditValue.Text = "EDIT";
            this.EditValue.UseVisualStyleBackColor = false;
            this.EditValue.Click += new System.EventHandler(this.EditValue_Click);
            // 
            // RemoveValue
            // 
            this.RemoveValue.BackColor = System.Drawing.Color.IndianRed;
            this.RemoveValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.RemoveValue.Enabled = false;
            this.RemoveValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveValue.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveValue.Location = new System.Drawing.Point(506, 0);
            this.RemoveValue.Name = "RemoveValue";
            this.RemoveValue.Size = new System.Drawing.Size(248, 63);
            this.RemoveValue.TabIndex = 9;
            this.RemoveValue.Text = "REMOVE";
            this.RemoveValue.UseVisualStyleBackColor = false;
            this.RemoveValue.Click += new System.EventHandler(this.RemoveValue_Click);
            // 
            // DomainListView
            // 
            this.DomainListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DomainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.DomainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DomainListView.FullRowSelect = true;
            this.DomainListView.GridLines = true;
            this.DomainListView.HideSelection = false;
            this.DomainListView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DomainListView.Location = new System.Drawing.Point(240, 0);
            this.DomainListView.MultiSelect = false;
            this.DomainListView.Name = "DomainListView";
            this.DomainListView.Size = new System.Drawing.Size(514, 110);
            this.DomainListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.DomainListView.TabIndex = 10;
            this.DomainListView.UseCompatibleStateImageBehavior = false;
            this.DomainListView.View = System.Windows.Forms.View.Details;
            this.DomainListView.ItemActivate += new System.EventHandler(this.DomainListView_ItemActivate);
            this.DomainListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.DomainListView_ItemSelectionChanged);
            this.DomainListView.SelectedIndexChanged += new System.EventHandler(this.DomainListView_SelectedIndexChanged);
            this.DomainListView.Leave += new System.EventHandler(this.DomainListView_Leave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "AddedValues";
            this.columnHeader1.Width = 510;
            // 
            // SaveDomain
            // 
            this.SaveDomain.BackColor = System.Drawing.Color.SeaGreen;
            this.SaveDomain.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveDomain.Enabled = false;
            this.SaveDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveDomain.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveDomain.Location = new System.Drawing.Point(0, 0);
            this.SaveDomain.Name = "SaveDomain";
            this.SaveDomain.Size = new System.Drawing.Size(754, 100);
            this.SaveDomain.TabIndex = 11;
            this.SaveDomain.Text = "SAVE";
            this.SaveDomain.UseVisualStyleBackColor = false;
            this.SaveDomain.Click += new System.EventHandler(this.SaveDomain_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 70);
            this.panel1.TabIndex = 12;
            // 
            // EnterDomainPanel
            // 
            this.EnterDomainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.EnterDomainPanel.Controls.Add(this.PanelLine_1);
            this.EnterDomainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.EnterDomainPanel.Location = new System.Drawing.Point(0, 70);
            this.EnterDomainPanel.Name = "EnterDomainPanel";
            this.EnterDomainPanel.Size = new System.Drawing.Size(754, 53);
            this.EnterDomainPanel.TabIndex = 14;
            // 
            // PanelLine_1
            // 
            this.PanelLine_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.PanelLine_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelLine_1.Controls.Add(this.panel5);
            this.PanelLine_1.Controls.Add(this.panel6);
            this.PanelLine_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLine_1.Location = new System.Drawing.Point(0, 0);
            this.PanelLine_1.Name = "PanelLine_1";
            this.PanelLine_1.Size = new System.Drawing.Size(754, 54);
            this.PanelLine_1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.DomainName);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(239, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(513, 52);
            this.panel5.TabIndex = 2;
            // 
            // DomainName
            // 
            this.DomainName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DomainName.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DomainName.Location = new System.Drawing.Point(0, 0);
            this.DomainName.Name = "DomainName";
            this.DomainName.Size = new System.Drawing.Size(513, 53);
            this.DomainName.TabIndex = 0;
            this.DomainName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DomainName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(239, 52);
            this.panel6.TabIndex = 1;
            // 
            // PanelLine_2
            // 
            this.PanelLine_2.Controls.Add(this.DomainListView);
            this.PanelLine_2.Controls.Add(this.panel3);
            this.PanelLine_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelLine_2.Location = new System.Drawing.Point(0, 123);
            this.PanelLine_2.Name = "PanelLine_2";
            this.PanelLine_2.Size = new System.Drawing.Size(754, 110);
            this.PanelLine_2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 110);
            this.panel3.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(240, 53);
            this.panel7.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.Value);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(240, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(514, 53);
            this.panel8.TabIndex = 3;
            // 
            // panelLine
            // 
            this.panelLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelLine.Controls.Add(this.panel8);
            this.panelLine.Controls.Add(this.panel7);
            this.panelLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLine.Location = new System.Drawing.Point(0, 233);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(754, 53);
            this.panelLine.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.AddValue);
            this.panel4.Controls.Add(this.RemoveValue);
            this.panel4.Controls.Add(this.EditValue);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 286);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(754, 63);
            this.panel4.TabIndex = 16;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.SaveDomain);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 349);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(754, 100);
            this.panel10.TabIndex = 18;
            // 
            // DomainAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(754, 449);
            this.Controls.Add(this.PanelLine_2);
            this.Controls.Add(this.panelLine);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.EnterDomainPanel);
            this.Controls.Add(this.panel1);
            this.Name = "DomainAddForm";
            this.Text = "DomainAddFormcs";
            this.Load += new System.EventHandler(this.DomainAddForm_Load);
            this.Resize += new System.EventHandler(this.DomainAddForm_Resize);
            this.panel1.ResumeLayout(false);
            this.EnterDomainPanel.ResumeLayout(false);
            this.PanelLine_1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.PanelLine_2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panelLine.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddValue;
        private System.Windows.Forms.Button EditValue;
        private System.Windows.Forms.Button RemoveValue;
        public System.Windows.Forms.TextBox Value;
        public System.Windows.Forms.ListView DomainListView;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button SaveDomain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel EnterDomainPanel;
        private System.Windows.Forms.Panel PanelLine_1;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.TextBox DomainName;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel PanelLine_2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panelLine;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel10;
    }
}