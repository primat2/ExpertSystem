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


namespace BestExpertSystem
{
    public partial class ConsultationForm : Form
    {
        enum ConsultationState { None, ChooseGoal, Dialog };

        private MODEL.MemoryComponent memory;
        private CORE.ExpertSystem expertSystem;
        private Application mainForm;
        private ConsultationState state = ConsultationState.None;

        private MODEL.Variable consultationGoal;
        private MODEL.VariableValue currentValue;
        private ManualResetEvent valueGetEvent;


        public ConsultationForm(MODEL.MemoryComponent Memory, CORE.ExpertSystem ExpertSystem, Application App)
        {
            InitializeComponent();
            this.valueGetEvent = new ManualResetEvent(false);

            memory = Memory;
            expertSystem = ExpertSystem;
            mainForm = App;

            ChooseConsultationGoal();
        }

        private void ChooseConsultationGoal()
        {
            state = ConsultationState.ChooseGoal;
            var availableVariables = memory.variables.Where(
                t => t.variableType == MODEL.VariableType.Deducible).ToArray();

            CB_DialogAnswers.Items.AddRange(availableVariables);

            lb_Dialog.Text = "Choose consultation goal!";
        }

        private void BtnDialogResponse_Click(object sender, EventArgs e)
        {
            if (CB_DialogAnswers.SelectedItem == null) return;

            if (state == ConsultationState.ChooseGoal)
            {
                consultationGoal = (MODEL.Variable)CB_DialogAnswers.SelectedItem;
                state = ConsultationState.Dialog;
                Task.Run(() => expertSystem.DeduceGoalVariable(consultationGoal));
                int x = 5;
                return;
            }
            else if (state == ConsultationState.Dialog)
            {
                currentValue = (MODEL.VariableValue)CB_DialogAnswers.SelectedItem;
                this.valueGetEvent.Set();
            }
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
