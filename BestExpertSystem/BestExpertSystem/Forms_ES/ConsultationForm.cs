using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.Text.Json;
using System.Text.Json.Serialization;


namespace BestExpertSystem
{
    public class TransferObj
    {
        public int ES_id { get; set; }
        public string GoalVar { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public TransferObj(int es_id = -1, string goalVar = "", string question = "", string answer = "")
        {
            ES_id = es_id;
            GoalVar = goalVar;
            Question = question;
            Answer = answer;
        }
    }


    public partial class ConsultationForm : Form
    {
        enum ConsultationState { None, ChooseGoal, Dialog, WaitingServer };

        private MODEL.MemoryComponent memory;
        private CORE.ExpertSystem expertSystem;
        private Application mainForm;
        private ConsultationState state = ConsultationState.None;

        private MODEL.Variable consultationGoal;
        private MODEL.VariableValue currentValue;
        private ManualResetEvent valueGetEvent;

        private SocketClient connectionToServer;

        ConsultationState State
        {
            get { return state; }
            set
            {
                if (value == ConsultationState.WaitingServer) BtnDialogResponse.Enabled = false;
                if (value == ConsultationState.Dialog) BtnDialogResponse.Enabled = true;
                state = value;
            }
        }


        public ConsultationForm(SocketClient ConnectionToServer, MODEL.MemoryComponent Memory, CORE.ExpertSystem ExpertSystem, Application App)
        {
            InitializeComponent();
            connectionToServer = ConnectionToServer;
            this.valueGetEvent = new ManualResetEvent(false);

            memory = Memory;
            expertSystem = ExpertSystem;
            mainForm = App;

            ChooseConsultationGoal();
        }

        private void ChooseConsultationGoal()
        {
            State = ConsultationState.ChooseGoal;
            var availableVariables = memory.variables.Where(
                t => t.variableType == MODEL.VariableType.Deducible).ToArray();

            CB_DialogAnswers.Items.AddRange(availableVariables);

            lb_Dialog.Text = "Choose consultation goal!";
        }

        private void BtnDialogResponse_Click(object sender, EventArgs e)
        {
            if (CB_DialogAnswers.SelectedItem == null) return;

            if (State == ConsultationState.ChooseGoal)
            {
                consultationGoal = (MODEL.Variable)CB_DialogAnswers.SelectedItem;
                State = ConsultationState.WaitingServer;
                //Task.Run(() => expertSystem.DeduceGoalVariable(consultationGoal));
                Task.Run(() => StartDeducingVariable(consultationGoal));
                return;
            }
            else if (State == ConsultationState.Dialog)
            {
                // todo: run task send these data to server
                currentValue = (MODEL.VariableValue)CB_DialogAnswers.SelectedItem;
                State = ConsultationState.WaitingServer;
                this.valueGetEvent.Set();
                Task.Run(() => ContinueDecucing(currentValue));
                
            }
        }


        private async void ContinueDecucing(MODEL.VariableValue variable)
        {
            var trO = new TransferObj(answer: variable.value);
            string jsonified = JsonSerializer.Serialize(trO) + "\n!";
            await connectionToServer.SendToServer(jsonified);

            State = ConsultationState.WaitingServer;

            await connectionToServer.ReadLineAsync((t) => OnServerQuestionRecieved(t));

        }

        private async void StartDeducingVariable(MODEL.Variable variable)
        {
            var trO = new TransferObj(es_id: 1, goalVar: variable.name);
            string jsonified = JsonSerializer.Serialize(trO) + "\n!";
            await connectionToServer.SendToServer(jsonified);

            State = ConsultationState.WaitingServer;

            await connectionToServer.ReadLineAsync((t) => OnServerQuestionRecieved(t));

        }





        public async void OnServerQuestionRecieved(TransferObj trOb)
        {
            // If answer has been drawn
            if (trOb.Answer != "")
            {
                MessageBox.Show(trOb.Answer);

                BeginInvoke(new Action(() =>
                {
                    lb_Dialog.Text = $"The drawn answer is: {trOb.Answer}";
                    CB_DialogAnswers.Items.Clear();
                    BtnDialogResponse.Enabled = false;

                    //CB_DialogAnswers.Items.AddRange(varQ.domain.values.ToArray());
                }));

                await connectionToServer.SendToServer("#");
                return;
            }

            var varQ = memory.ParseVariable(trOb.GoalVar);
            BeginInvoke(new Action(() =>
            {
                lb_Dialog.Text = varQ.question;
                CB_DialogAnswers.Items.Clear();
                CB_DialogAnswers.Items.AddRange(varQ.domain.values.ToArray());
                State = ConsultationState.Dialog;
            }));
        }





        public MODEL.VariableValue AskNextQuestion(MODEL.Variable variable)
        {
            BeginInvoke(new Action(() =>
            {
                lb_Dialog.Text = variable.question;
                CB_DialogAnswers.Items.Clear();
                CB_DialogAnswers.Items.AddRange(variable.domain.values.ToArray());
            }));

            this.valueGetEvent.WaitOne();
            this.valueGetEvent.Reset();
            return currentValue;
        }

        public void VariableDeduced(MODEL.VariableValue value)
        {
            BeginInvoke(new Action(() =>
            {
                if (value == null)
                {
                    //this.AddMessage(new ConsultationMessage(MessageType.Error,
                    //    "Цель консультации не была достигнута.\nОбратитесь к другой ЭС."));
                    lb_Dialog.Text = "Consultation cannot be given";
                }
                else
                {
                    //this.AddMessage(new ConsultationMessage(MessageType.Result,
                    //    "Цель консультации достигнута!\nРезультат:" + string.Format("\n{0} - {1}",
                    //        this.ExpertSystemShell.GoalVariable.Name, value.Name)));
                    lb_Dialog.Text = $"Answer: {value.ToString()}";
                }

            }));
        }

    }
}
