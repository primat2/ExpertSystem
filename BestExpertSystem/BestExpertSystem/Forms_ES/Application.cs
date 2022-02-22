using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace BestExpertSystem
{
    public partial class Application : Form
    {
        public static Application instance;

        private ListViewItem selectedItem;


        public UI_LOGICK.UI_Domain UI_DomainWorker;
        public UI_LOGICK.UI_Variable UI_VariableWorker;
        public UI_LOGICK.UI_Rule UI_RuleWorker;


        private ListViewItem dragging;

        private int draggingRuleIndex;
        private int draggingVarIndex;
        private int draggingDomainIndex;

        bool isMouseOverRulesLV;


        // *** MODEL ***
        private MODEL.MemoryComponent memory;

        // *** CORE ***
        private CORE.ExpertSystem expertSystem;


        // *** Networking ***
        private IPAddress ipAddress;
        private string strPortInput = "23000";
        private ManualResetEvent valueGetEvent;
        SocketClient connectionToServer;

        int ES_id;
        int user_id;
        string ES_name;

        // *******************
        // Working with memory
        // *******************

        private void DomainsChangedHandler()
        {
            UI_LOGICK.Util.UpdateListView(ListViewDomes, memory.domains);
        }

        private void VariablesChangedHandler()
        {
            UI_LOGICK.Util.UpdateListView(listViewVars, memory.variables);
        }

        private void RulesChangedHandler()
        {
            UI_LOGICK.Util.UpdateListView(ListViewRules, memory.rules);
        }

        //string connectionString = "Server=LAPTOP-0NS5LUQ8;Database=ExpertSystems;Trusted_Connection=True;";
        //string connectionString = "Server=tcp:primatserver.database.windows.net,1433;Initial Catalog=ExpertSystemDB;Persist Security Info=False;User ID=primat;Password=Ilyamechmat90;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public Application(string ES_name, int EsID = -1, int userID = -1)
        {
            instance = this;
            this.ES_id = EsID;
            this.ES_name = ES_name;
            this.user_id = userID;
            memory = new MODEL.MemoryComponent();
            expertSystem = new CORE.ExpertSystem(memory);

            ipAddress = DataBaseWorker.GetServerIP();
            this.valueGetEvent = new ManualResetEvent(false);
            //client.ConnectToServer(valueGetEvent);


            //connectionToServer = new SocketClient(ipAddress, 23000);
            //Task.Run(() => connectionToServer.ConnectToServer(valueGetEvent));
            //valueGetEvent.WaitOne();
            //valueGetEvent.Reset();

            UI_DomainWorker = new UI_LOGICK.UI_Domain(this);
            UI_VariableWorker = new UI_LOGICK.UI_Variable(this);
            UI_RuleWorker = new UI_LOGICK.UI_Rule(this);

            if (EsID >= 0)
            {

                DataBaseWorker.LoadData(EsID, memory);
            }
            else
            {
                memory.domains = new DATA_TYPES.OrderedList<MODEL.Domain>();
                memory.variables = new DATA_TYPES.OrderedList<MODEL.Variable>();
                memory.rules = new DATA_TYPES.OrderedList<MODEL.Rule>();
            }

            // Managing events
            memory.domainsChanged += DomainsChangedHandler;
            memory.variablesChanged += VariablesChangedHandler;
            memory.rulesChanged += RulesChangedHandler;

            //memory.domains.Add(new MODEL.Domain("123", new List<MODEL.VariableValue>() { new MODEL.VariableValue("12334") }));


            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var rule in memory.rules)
            {
                UI_LOGICK.Util.AddToListView(ListViewRules, rule);
            }

            foreach (var variable in memory.variables)
            {
                UI_LOGICK.Util.AddToListView(listViewVars, variable);
            }

            foreach (var domain in memory.domains)
            {
                UI_LOGICK.Util.AddToListView(ListViewDomes, domain);
            }

            panelQuestion.Visible = false;
            panelDomains.Visible = false;
            panelDescendant.Visible = true;
            panelAntecedent.Visible = true;
            UpdateControls();
        }

        private void UpdateDomainListView()
        {
            listViewDomains.Clear();

            if (tabControl.SelectedIndex == 1 && listViewVars.SelectedItems.Count > 0)
            {
                DopInfoLabelHeader.Text += "1";
                var selected = listViewVars.SelectedItems[0];
                int selectedIndex = selected.Index;
                var variable = memory.variables[selectedIndex];

                for (int i = 0; i < variable.domain.values.Count; i++)
                {
                    listViewDomains.Items.Add(variable.domain.values[i].Value);
                }
            }
            if (tabControl.SelectedIndex == 2 && ListViewDomes.SelectedItems.Count > 0)
            {
                DopInfoLabelHeader.Text += "2";

                var selected = ListViewDomes.SelectedItems[0];
                int selectedIndex = selected.Index;
                var domain = memory.domains[selectedIndex];

                for (int i = 0; i < domain.values.Count; i++)
                {
                    listViewDomains.Items.Add(domain.values[i].Value);
                }
            }
        }

        private void UpdateControls()
        {
            UpdateDomainListView();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listViewAnts
            //listViewDescs
            listViewAnts.Clear();
            listViewDescs.Clear();

            if (ListViewRules.SelectedItems.Count == 0) return;

            int idxRule = ListViewRules.SelectedItems[0].Index;
            MODEL.Rule ruleByIdx = memory.rules[idxRule];

            for (int i = 0; i < ruleByIdx.antecedents.Count; i++)
            {
                listViewAnts.Items.Add(ruleByIdx.antecedents[i].ToString());
            }
            for (int i = 0; i < ruleByIdx.descendants.Count; i++)
            {
                listViewDescs.Items.Add(ruleByIdx.descendants[i].ToString());
            }
        }

        // *************
        // Add Button
        // *************
        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabPageRules")
            {
                //AddRule();
                UI_RuleWorker.AddRule();
            }
            if (tabControl.SelectedTab.Name == "tabPageVars")
            {
                UI_VariableWorker.AddVairable();
            }
            if (tabControl.SelectedTab.Name == "tabPageDomes")
            {
                UI_DomainWorker.AddDomain();
            }
        }

        // *************
        // Change Button
        // *************
        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                return;
            }

            if (tabControl.SelectedTab.Name == "tabPageRules")
            {
                EditRule();
            }
            if (tabControl.SelectedTab.Name == "tabPageVars")
            {
                var varToChange = memory.variables[selectedItem.Index];
                UI_VariableWorker.ChangeVariable(varToChange);

            }
            if (tabControl.SelectedTab.Name == "tabPageDomes")
            {
                // var selected = ListViewDomes.SelectedItems[0];
                var domainToChange = memory.domains[selectedItem.Index];
                UI_DomainWorker.ChangeDomain(domainToChange);
            }
        }

        // *************
        // Delete Button
        // *************
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = selectedItem.Index;

            if (tabControl.SelectedTab.Name == "tabPageRules")
            {
                memory.DeleteItem<MODEL.Rule>(index);
            }
            if (tabControl.SelectedTab.Name == "tabPageVars")
            {
                memory.DeleteItem<MODEL.Variable>(index);

            }
            if (tabControl.SelectedTab.Name == "tabPageDomes")
            {
                memory.DeleteItem<MODEL.Domain>(index);
            }
        }


        private void AddToListBox(string name, string desc, string content)
        {
            ListViewItem lstViewItem = ListViewRules.Items.Add(name);
            lstViewItem.SubItems.Add(desc);
            lstViewItem.SubItems.Add(content);
        }


        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Пожалуйста введите все обязательные (*) поля");
        }



        // *** Selection Changed ***
        private void ListViewNames_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedItem = e.Item;

        }
        private void ListViewDomes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedItem = e.Item;
        }
        private void listViewVars_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedItem = e.Item;
        }


       






        private void AddRule()
        {
            var myHappyNewForm = new RuleAddForm();
            myHappyNewForm.Text = "Добавление правила";

            DialogResult dResult = myHappyNewForm.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                AddToListBox(myHappyNewForm.textBoxName.Text, myHappyNewForm.textBoxDesc.Text, myHappyNewForm.textBoxContent.Text);

            }
        }

        

        private void EditRule()
        {
            if (selectedItem == null) return;

            var myHappyNewForm = new RuleAddForm();
            myHappyNewForm.Text = "Изменение правила";

            myHappyNewForm.textBoxName.Text = selectedItem.Text;
            myHappyNewForm.textBoxDesc.Text = selectedItem.SubItems[1].Text;
            myHappyNewForm.textBoxContent.Text = selectedItem.SubItems[2].Text;

            DialogResult dResult = myHappyNewForm.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                selectedItem.Text = myHappyNewForm.textBoxName.Text;
                selectedItem.SubItems[1].Text = myHappyNewForm.textBoxDesc.Text;
                selectedItem.SubItems[2].Text = myHappyNewForm.textBoxContent.Text;

            }
        }






        //private void UpdateListView()
        //{
        //    ListViewRules.Items.Clear();
        //    foreach (var rule in memory.rules)
        //    {
        //        UI_LOGICK.Util.AddToListView(ListViewRules, rule);
        //        //ListViewRules.Items.Add(rule);
        //    }
        //}




        //**************
        // DRAG AND DROP 
        //**************

        // *** COMMON ***
        private void StartDragAndDrop(ref int draggingItemIndex, ItemDragEventArgs e)
        {
            var item = (ListViewItem)e.Item;

            draggingItemIndex = item.Index;
            dragging = (ListViewItem)item.Clone();

            string s = e.Item.ToString();
            DoDragDrop(s, DragDropEffects.Move);
        }

        // *** DRAG AND DROP RULES ***    

        private void ListViewRules_DragDrop(object sender, DragEventArgs e)
        {
            // МЕНЯТЬ СРАЗУ ПОРЯДОК В СПИСКЕ, А ПОТОМ ПРОСТО ОБНОВЛЯТЬ ВЕСЬ ЛИСТ ВЬЮ СОГЛАСНО ЭТОМу СПИСКУ

            UI_LOGICK.Util.DoDragDrop(ListViewRules, draggingRuleIndex, e, memory.rules);
            dragging = null;
        }

        private void ListViewRules_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = UI_LOGICK.Util.GetDragEnterEffect(e);
        }

        private void ListViewRules_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = UI_LOGICK.Util.GetDragOverEffect(ListViewRules, e, isMouseOverRulesLV);
        }

        private void ListViewRules_ItemDrag(object sender, ItemDragEventArgs e)
        {
            StartDragAndDrop(ref draggingRuleIndex, e);
        }

        // *** DRAG AND DROP VARIABLES ***


        private void listViewVars_DragDrop(object sender, DragEventArgs e)
        {
            UI_LOGICK.Util.DoDragDrop(listViewVars, draggingVarIndex, e, memory.variables);
            dragging = null;
        }

        private void listViewVars_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = UI_LOGICK.Util.GetDragEnterEffect(e);
        }

        private void listViewVars_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = UI_LOGICK.Util.GetDragOverEffect(listViewVars, e, isMouseOverRulesLV);
        }

        private void listViewVars_ItemDrag(object sender, ItemDragEventArgs e)
        {
            StartDragAndDrop(ref draggingVarIndex, e);
        }

        // *** DRAG AND DROP DOMAINS ***

        private void ListViewDomes_DragDrop(object sender, DragEventArgs e)
        {
            UI_LOGICK.Util.DoDragDrop(ListViewDomes, draggingDomainIndex, e, memory.domains);
            dragging = null;
        }

        private void ListViewDomes_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = UI_LOGICK.Util.GetDragEnterEffect(e);
        }
        private void ListViewDomes_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = UI_LOGICK.Util.GetDragOverEffect(ListViewDomes, e, isMouseOverRulesLV);
        }

        private void ListViewDomes_ItemDrag(object sender, ItemDragEventArgs e)
        {
            StartDragAndDrop(ref draggingDomainIndex, e);
        }




        private void ListViewRules_MouseHover(object sender, EventArgs e)
        {
            isMouseOverRulesLV = true;
        }

        private void ListViewRules_MouseLeave(object sender, EventArgs e)
        {
            isMouseOverRulesLV = false;
        }



        private void ResizeListView(ListView listView)
        {
            int columns = listView.Columns.Count;
            float widthPerColumn = (listView.Width - 50) / (columns - 1);
            for (int i = 1; i < columns; i++)
            {
                listView.Columns[i].Width = (int)widthPerColumn;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeListView(ListViewRules);
            ResizeListView(listViewVars);
            ResizeListView(ListViewDomes);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                panelQuestion.Visible = false;
                panelDomains.Visible = false;
                panelDescendant.Visible = true;
                panelAntecedent.Visible = true;
            }
            if (tabControl.SelectedIndex == 1)
            {
                panelQuestion.Visible = true;
                panelDomains.Visible = true;
                panelDescendant.Visible = false;
                panelAntecedent.Visible = false;
            }
            if (tabControl.SelectedIndex == 2)
            {
                panelQuestion.Visible = false;
                panelDomains.Visible = true;
                panelDescendant.Visible = false;
                panelAntecedent.Visible = false;
            }
        }

        private void Application_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ListViewRules_Leave(object sender, EventArgs e)
        {
            //selectedItem = null;
        }

        private void listViewVars_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateDomainListView();
        }

        private void listViewVars_Leave(object sender, EventArgs e)
        {
            UpdateDomainListView();
        }

        private void ListViewDomes_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateDomainListView();
        }

        private void ListViewDomes_Leave(object sender, EventArgs e)
        {
            UpdateDomainListView();
        }

        private void listViewVars_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDomainListView();
        }

        private void ListViewDomes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDomainListView();
        }

        private void начатьКонсультациюToolStripMenuItem_Click(object sender, EventArgs e)
        {

            connectionToServer = new SocketClient(ipAddress, 23000);
            Task.Run(() => connectionToServer.ConnectToServer(valueGetEvent));

            var consultationForm = new ConsultationForm_NEW(this.ES_id, connectionToServer, memory, expertSystem, this);
            expertSystem.InitES(consultationForm);
            DialogResult dResult = consultationForm.ShowDialog();

            if (connectionToServer.IsConnected)
            {
                connectionToServer.CloseAndDisconnect();
            }


            //if (dResult == DialogResult.OK)
            //{
            //    string name = myHappyNewForm.VariableName.Text;
            //    string explanation = myHappyNewForm.RuleExplaination.Text;

            //    List<MODEL.Fact> Antecedents = myHappyNewForm.Ants;
            //    List<MODEL.Fact> Descendants = myHappyNewForm.Descs;


            //    newRule = new MODEL.Rule(order, name, Antecedents, Descendants, explanation);
            //    memory.AddOrUpdateRule(newRule);

            //}
        }





        private void listViewVars_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Debug.WriteLine(memory);
        }

        private void открытьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileParser.Parse(memory);
            UI_LOGICK.Util.UpdateListView(listViewVars, memory.variables);
            UI_LOGICK.Util.UpdateListView(ListViewRules, memory.rules);
            UI_LOGICK.Util.UpdateListView(ListViewDomes, memory.domains);
        }

        private void сохранитьВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileParser.Write(memory);
        }

        private void сохранитьВБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseWorker.WriteToBD(this.user_id, "new es", memory);
        }
    }
}
