using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;
using System.Threading;

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
        string connectionString = "Server=tcp:primatserver.database.windows.net,1433;Initial Catalog=ExpertSystemDB;Persist Security Info=False;User ID=primat;Password=Ilyamechmat90;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public Application(int EsID = -1)
        {
            instance = this;
            memory = new MODEL.MemoryComponent();
            expertSystem = new CORE.ExpertSystem(memory);

            GetServerIP();
            this.valueGetEvent = new ManualResetEvent(false);
            //client.ConnectToServer(valueGetEvent);


            //connectionToServer = new SocketClient(ipAddress, 23000);
            //Task.Run(() => connectionToServer.ConnectToServer(valueGetEvent));
            //valueGetEvent.WaitOne();
            //valueGetEvent.Reset();



            // Managing events
            memory.domainsChanged += DomainsChangedHandler;
            memory.variablesChanged += VariablesChangedHandler;
            memory.rulesChanged += RulesChangedHandler;

            UI_DomainWorker = new UI_LOGICK.UI_Domain(this);
            UI_VariableWorker = new UI_LOGICK.UI_Variable(this);
            UI_RuleWorker = new UI_LOGICK.UI_Rule(this);

            if (EsID >= 0)
            {
                LoadData(EdID);
            }

            InitializeComponent();
        }


        private void GetServerIP()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                string sql = "SELECT * FROM FreeServers WHERE server_load = (SELECT MIN(server_load) FROM FreeServers)";
                SqlCommand sqlCommand = new SqlCommand(sql, cnn);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                string strIp = (string)reader.GetValue(1);

                ipAddress = IPAddress.Parse(strIp);
                cnn.Close();
            }

        }


        private void LoadData(int EsID)
        {
            memory.domains = new DATA_TYPES.OrderedList<MODEL.Domain>();
            memory.variables = new DATA_TYPES.OrderedList<MODEL.Variable>();
            memory.rules = new DATA_TYPES.OrderedList<MODEL.Rule>();

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                // *** GETTING DOMAINS ***
                string sqlGetDomainsCount = "SELECT COUNT(*) FROM VarDomains";
                SqlCommand sqlCommand = new SqlCommand(sqlGetDomainsCount, cnn);
                int numberOfDomains = (int)sqlCommand.ExecuteScalar();

                for (int i = 1; i <= numberOfDomains; i++)
                {
                    MODEL.Domain newDomain;
                    string domainName = "";
                    List<string> domainValues = new List<string>();

                    string sql_getDomains = "SELECT * FROM VarDomains JOIN DomainValues ON VarDomains.id = DomainValues.domain_id WHERE VarDomains.id = @domID";
                    SqlCommand sqlCommand2 = new SqlCommand(sql_getDomains, cnn);
                    sqlCommand2.Parameters.AddWithValue("@domID", i);
                    SqlDataReader reader = sqlCommand2.ExecuteReader();

                    while (reader.Read())
                    {
                        domainName = (string)reader.GetValue(reader.GetOrdinal("name"));
                        string domainValue = (string)reader.GetValue(reader.GetOrdinal("value"));
                        domainValues.Add(domainValue);

                    }

                    newDomain = new MODEL.Domain(domainName, domainValues);
                    memory.domains.Add(newDomain);
                    reader.Close();
                }


                // *** GETTING VARIABLES ***

                string sql_getVariables = "SELECT * FROM Variables JOIN VarDomains ON Variables.domain_id = VarDomains.id";
                SqlCommand sqlCommandVars = new SqlCommand(sql_getVariables, cnn);
                SqlDataReader readerVars = sqlCommandVars.ExecuteReader();

                while (readerVars.Read())
                {
                    string varName = (string)readerVars.GetValue(readerVars.GetOrdinal("name"));
                    string question = (string)readerVars.GetValue(readerVars.GetOrdinal("question"));
                    string domainName = (string)readerVars.GetValue(7);
                    string var_type = (string)readerVars.GetValue(readerVars.GetOrdinal("var_type"));

                    var newVar = new MODEL.Variable(varName, question, memory.ParseDomain(domainName), memory.ParseVarType(var_type));
                    memory.variables.Add(newVar);
                }
                readerVars.Close();


                // *** GETTING RULES ***
                List<MODEL.Fact> premises = new List<MODEL.Fact>(); 
                List<MODEL.Fact> conclusions = new List<MODEL.Fact>(); 

                // GETTING THE NUMBER OF RULES
                string sqlNumOfRules = "SELECT COUNT(DISTINCT rule_id) FROM Facts";
                SqlCommand commandNumOfFacts = new SqlCommand(sqlNumOfRules, cnn);
                int numberOfRules = (int)commandNumOfFacts.ExecuteScalar();

                for (int i = 1; i <= numberOfRules; i++)
                {
                    string ruleName = "";
                    string explain = "";
                    // GETTING NAME AND EXPLAIN
                    string ruleInfo = "SELECT * FROM EsRules WHERE EsRules.id = @ruleID";
                    SqlCommand ruleInfoCommand = new SqlCommand(ruleInfo, cnn);
                    ruleInfoCommand.Parameters.AddWithValue("@ruleID", i);
                    SqlDataReader ruleInfoReader = ruleInfoCommand.ExecuteReader();
                    ruleInfoReader.Read();
                    ruleName = (string)ruleInfoReader.GetValue(ruleInfoReader.GetOrdinal("name"));
                    explain = (string)ruleInfoReader.GetValue(ruleInfoReader.GetOrdinal("explain"));
                    ruleInfoReader.Close();

                    // GETTING PREMISES
                    string sqlPremisesFacts = "SELECT * FROM Facts JOIN Variables ON Facts.var_id = Variables.id WHERE Facts.rule_id = @ruleID AND Facts.is_premise = 1";
                    SqlCommand commandPremisesFacts = new SqlCommand(sqlPremisesFacts, cnn);
                    commandPremisesFacts.Parameters.AddWithValue("@ruleID", i);
                    SqlDataReader readerPremisesFacts = commandPremisesFacts.ExecuteReader();

                    while (readerPremisesFacts.Read())
                    {
                        string varName = (string)readerPremisesFacts.GetValue(readerPremisesFacts.GetOrdinal("name"));
                        string factValue = (string)readerPremisesFacts.GetValue(readerPremisesFacts.GetOrdinal("value"));

                        var newFact = new MODEL.Fact(memory.ParseVariable(varName), new MODEL.VariableValue(factValue));
                        premises.Add(newFact);
                    }
                    readerPremisesFacts.Close();

                    // GETTING CONCLUSIONS
                    string sqlConclusionFacts = "SELECT * FROM Facts JOIN Variables ON Facts.var_id = Variables.id WHERE Facts.rule_id = @ruleID AND Facts.is_premise = 0";
                    SqlCommand commandConclusionFacts = new SqlCommand(sqlConclusionFacts, cnn);
                    commandConclusionFacts.Parameters.AddWithValue("@ruleID", i);
                    SqlDataReader readerConclusionFacts = commandConclusionFacts.ExecuteReader();

                    while (readerConclusionFacts.Read())
                    {
                        string varName = (string)readerConclusionFacts.GetValue(readerConclusionFacts.GetOrdinal("name"));
                        string factValue = (string)readerConclusionFacts.GetValue(readerConclusionFacts.GetOrdinal("value"));

                        var newFact = new MODEL.Fact(memory.ParseVariable(varName), new MODEL.VariableValue(factValue));
                        conclusions.Add(newFact);
                    }
                    readerConclusionFacts.Close();

                    var newRule = new MODEL.Rule(ruleName, premises, conclusions, explain);
                    memory.rules.Add(newRule);
                }


                cnn.Close();
            }

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

            var consultationForm = new ConsultationForm(connectionToServer, memory, expertSystem, this);
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
    }
}
