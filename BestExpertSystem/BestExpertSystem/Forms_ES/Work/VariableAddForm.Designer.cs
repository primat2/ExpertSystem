namespace BestExpertSystem
{
    partial class VariableAddForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.label2 = new System.Windows.Forms.Label();
            this.VariableName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.VarDomainComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VarTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.VariableQuestion = new System.Windows.Forms.TextBox();
            this.AddContextDomain = new System.Windows.Forms.Button();
            this.AddVariableButton = new System.Windows.Forms.Button();
            this.ButChangeSelectedDomain = new System.Windows.Forms.Button();
            this.DomainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.VariableHeader = new System.Windows.Forms.Label();
            this.DoaminLine_1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DomainLine_2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel_line_dom = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.DoaminLine_1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.DomainLine_2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel_line_dom.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 53);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name Of Variable";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VariableName
            // 
            this.VariableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariableName.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VariableName.Location = new System.Drawing.Point(0, 0);
            this.VariableName.Name = "VariableName";
            this.VariableName.Size = new System.Drawing.Size(511, 53);
            this.VariableName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 61);
            this.label3.TabIndex = 5;
            this.label3.Text = "Domain";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VarDomainComboBox
            // 
            this.VarDomainComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VarDomainComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VarDomainComboBox.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VarDomainComboBox.FormattingEnabled = true;
            this.VarDomainComboBox.IntegralHeight = false;
            this.VarDomainComboBox.ItemHeight = 49;
            this.VarDomainComboBox.Location = new System.Drawing.Point(0, 0);
            this.VarDomainComboBox.MinimumSize = new System.Drawing.Size(50, 0);
            this.VarDomainComboBox.Name = "VarDomainComboBox";
            this.VarDomainComboBox.Size = new System.Drawing.Size(513, 57);
            this.VarDomainComboBox.TabIndex = 7;
            this.VarDomainComboBox.SelectedIndexChanged += new System.EventHandler(this.VarDomainComboBox_SelectedIndexChanged);
            this.VarDomainComboBox.SelectedValueChanged += new System.EventHandler(this.VarDomainComboBox_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 56);
            this.label4.TabIndex = 8;
            this.label4.Text = "Type:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VarTypeComboBox
            // 
            this.VarTypeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VarTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VarTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VarTypeComboBox.FormattingEnabled = true;
            this.VarTypeComboBox.Items.AddRange(new object[] {
            "Requested",
            "Deducible",
            "RequestedDeducible"});
            this.VarTypeComboBox.Location = new System.Drawing.Point(0, 0);
            this.VarTypeComboBox.MinimumSize = new System.Drawing.Size(50, 0);
            this.VarTypeComboBox.Name = "VarTypeComboBox";
            this.VarTypeComboBox.Size = new System.Drawing.Size(514, 59);
            this.VarTypeComboBox.TabIndex = 9;
            this.VarTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.VarTypeComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 67);
            this.label5.TabIndex = 10;
            this.label5.Text = "Question:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VariableQuestion
            // 
            this.VariableQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariableQuestion.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VariableQuestion.Location = new System.Drawing.Point(305, 0);
            this.VariableQuestion.Name = "VariableQuestion";
            this.VariableQuestion.Size = new System.Drawing.Size(514, 46);
            this.VariableQuestion.TabIndex = 11;
            this.VariableQuestion.TextChanged += new System.EventHandler(this.VariableQuestion_TextChanged);
            // 
            // AddContextDomain
            // 
            this.AddContextDomain.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.AddContextDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddContextDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddContextDomain.Font = new System.Drawing.Font("Trebuchet MS", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddContextDomain.Location = new System.Drawing.Point(0, 0);
            this.AddContextDomain.Name = "AddContextDomain";
            this.AddContextDomain.Size = new System.Drawing.Size(131, 61);
            this.AddContextDomain.TabIndex = 12;
            this.AddContextDomain.Text = "Add new";
            this.AddContextDomain.UseVisualStyleBackColor = false;
            this.AddContextDomain.Click += new System.EventHandler(this.AddContextDomain_Click);
            // 
            // AddVariableButton
            // 
            this.AddVariableButton.BackColor = System.Drawing.Color.SeaGreen;
            this.AddVariableButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddVariableButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddVariableButton.Enabled = false;
            this.AddVariableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddVariableButton.Font = new System.Drawing.Font("Trebuchet MS", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddVariableButton.Location = new System.Drawing.Point(0, 410);
            this.AddVariableButton.Name = "AddVariableButton";
            this.AddVariableButton.Size = new System.Drawing.Size(819, 100);
            this.AddVariableButton.TabIndex = 13;
            this.AddVariableButton.Text = "ADD";
            this.AddVariableButton.UseVisualStyleBackColor = false;
            this.AddVariableButton.Click += new System.EventHandler(this.AddVariableButton_Click);
            // 
            // ButChangeSelectedDomain
            // 
            this.ButChangeSelectedDomain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ButChangeSelectedDomain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButChangeSelectedDomain.Enabled = false;
            this.ButChangeSelectedDomain.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButChangeSelectedDomain.Location = new System.Drawing.Point(0, 283);
            this.ButChangeSelectedDomain.Name = "ButChangeSelectedDomain";
            this.ButChangeSelectedDomain.Size = new System.Drawing.Size(819, 39);
            this.ButChangeSelectedDomain.TabIndex = 14;
            this.ButChangeSelectedDomain.Text = "Change";
            this.ButChangeSelectedDomain.UseVisualStyleBackColor = false;
            this.ButChangeSelectedDomain.Click += new System.EventHandler(this.ButChangeSelectedDomain_Click);
            // 
            // DomainListView
            // 
            this.DomainListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DomainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.DomainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DomainListView.FullRowSelect = true;
            this.DomainListView.GridLines = true;
            this.DomainListView.HideSelection = false;
            this.DomainListView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DomainListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.DomainListView.Location = new System.Drawing.Point(0, 0);
            this.DomainListView.Name = "DomainListView";
            this.DomainListView.Size = new System.Drawing.Size(819, 283);
            this.DomainListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.DomainListView.TabIndex = 15;
            this.DomainListView.UseCompatibleStateImageBehavior = false;
            this.DomainListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Domain Values";
            this.columnHeader1.Width = 630;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.VariableHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 70);
            this.panel1.TabIndex = 16;
            // 
            // VariableHeader
            // 
            this.VariableHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.VariableHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariableHeader.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VariableHeader.ForeColor = System.Drawing.Color.White;
            this.VariableHeader.Location = new System.Drawing.Point(0, 0);
            this.VariableHeader.Name = "VariableHeader";
            this.VariableHeader.Size = new System.Drawing.Size(819, 70);
            this.VariableHeader.TabIndex = 1;
            this.VariableHeader.Text = "Adding Domain";
            this.VariableHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DoaminLine_1
            // 
            this.DoaminLine_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DoaminLine_1.Controls.Add(this.panel4);
            this.DoaminLine_1.Controls.Add(this.panel3);
            this.DoaminLine_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.DoaminLine_1.Location = new System.Drawing.Point(0, 70);
            this.DoaminLine_1.Name = "DoaminLine_1";
            this.DoaminLine_1.Size = new System.Drawing.Size(819, 55);
            this.DoaminLine_1.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.VariableName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(306, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(513, 55);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(306, 55);
            this.panel3.TabIndex = 0;
            // 
            // DomainLine_2
            // 
            this.DomainLine_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DomainLine_2.Controls.Add(this.panel6);
            this.DomainLine_2.Controls.Add(this.panel5);
            this.DomainLine_2.Controls.Add(this.panel2);
            this.DomainLine_2.Dock = System.Windows.Forms.DockStyle.Top;
            this.DomainLine_2.Location = new System.Drawing.Point(0, 125);
            this.DomainLine_2.Name = "DomainLine_2";
            this.DomainLine_2.Size = new System.Drawing.Size(819, 63);
            this.DomainLine_2.TabIndex = 18;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.VarDomainComboBox);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(306, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(513, 63);
            this.panel6.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(133, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(173, 63);
            this.panel5.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.AddContextDomain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(133, 63);
            this.panel2.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel8.Controls.Add(this.DomainListView);
            this.panel8.Controls.Add(this.ButChangeSelectedDomain);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 188);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(819, 322);
            this.panel8.TabIndex = 20;
            // 
            // panel_line_dom
            // 
            this.panel_line_dom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel_line_dom.Controls.Add(this.panel11);
            this.panel_line_dom.Controls.Add(this.panel10);
            this.panel_line_dom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_line_dom.Location = new System.Drawing.Point(0, 283);
            this.panel_line_dom.Name = "panel_line_dom";
            this.panel_line_dom.Size = new System.Drawing.Size(819, 58);
            this.panel_line_dom.TabIndex = 14;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.VarTypeComboBox);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(305, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(514, 58);
            this.panel11.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.label4);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(305, 58);
            this.panel10.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel9.Controls.Add(this.VariableQuestion);
            this.panel9.Controls.Add(this.panel12);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 341);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(819, 69);
            this.panel9.TabIndex = 15;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.label5);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(305, 69);
            this.panel12.TabIndex = 0;
            // 
            // VariableAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(819, 510);
            this.Controls.Add(this.panel_line_dom);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.AddVariableButton);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.DomainLine_2);
            this.Controls.Add(this.DoaminLine_1);
            this.Controls.Add(this.panel1);
            this.Name = "VariableAddForm";
            this.Text = "VariableAddForm";
            this.Load += new System.EventHandler(this.VariableAddForm_Load);
            this.panel1.ResumeLayout(false);
            this.DoaminLine_1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.DomainLine_2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel_line_dom.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox VariableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox VariableQuestion;
        private System.Windows.Forms.Button AddContextDomain;
        private System.Windows.Forms.Button AddVariableButton;
        public System.Windows.Forms.ComboBox VarDomainComboBox;
        public System.Windows.Forms.ComboBox VarTypeComboBox;
        private System.Windows.Forms.Button ButChangeSelectedDomain;
        public System.Windows.Forms.ListView DomainListView;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label VariableHeader;
        private System.Windows.Forms.Panel DoaminLine_1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel DomainLine_2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel_line_dom;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel12;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}