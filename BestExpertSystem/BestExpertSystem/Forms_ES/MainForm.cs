using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestExpertSystem.Forms_ES
{
    public partial class MainForm : Form
    {
        string connectionString = "Server=tcp:primatserver.database.windows.net,1433;Initial Catalog=ExpertSystemDB;Persist Security Info=False;User ID=primat;Password=Ilyamechmat90;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private int authenticatedUserID = -1;
        private string authenticatedUserLogin = "";


        public MainForm()
        {
            InitializeComponent();
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                // *** GETTING EXPERT SYSTEMS ***
                string getExpertSystems = "SELECT * FROM ExpertSystems JOIN Users ON ExpertSystems.owner_id = Users.id";
                SqlCommand sqlCommand = new SqlCommand(getExpertSystems, cnn);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader.GetValue(0).ToString());
                    string esName = reader.GetValue(1).ToString();
                    string owner = (string)reader.GetValue(4);

                    AddToLv(id, esName, owner);
                }
                reader.Close();
            }
        }

        private void AddToLv(int id, string esName, string owner)
        {
            var item = lvExpertSystems.Items.Add(esName);
            item.Tag = id;
            item.SubItems.Add(owner);
        }


        public static string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }


        private void Authenticate(string login, string password)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                // *** GETTING EXPERT SYSTEMS ***
                string getExpertSystems = "SELECT * FROM ExpertSystems JOIN Users ON ExpertSystems.owner_id = Users.id WHERE Users.name = @login AND Users.pass = @pass";
                SqlCommand sqlCommand = new SqlCommand(getExpertSystems, cnn);
                sqlCommand.Parameters.AddWithValue("@login", login);
                sqlCommand.Parameters.AddWithValue("@pass", sha256_hash(password));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (!reader.HasRows)
                {
                    //DialogBox
                    var confirmForm = new Forms_ES.TMP.CreateUserConfirm();
                    var result = confirmForm.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        CreateUser(cnn, login, password);
                    }
                    return;
                }

                reader.Read();
                RegisterUser(login, int.Parse(reader.GetValue(0).ToString()));
            }
        }

        private void RegisterUser(string login, int id)
        {
            authenticatedUserLogin = login;
            authenticatedUserID = id;
            panelAuthFull.Visible = false;
            lblHello.Text = $"Hello, {login}!";
        }

        private void CreateUser(SqlConnection cnn, string login, string password)
        {
            string sql = "INSERT INTO Users(name, pass) output INSERTED.ID VALUES ('@login', '@hash')";
            SqlCommand sqlCommand = new SqlCommand(sql, cnn);
            sqlCommand.Parameters.AddWithValue("@login", login);
            sqlCommand.Parameters.AddWithValue("@hash", sha256_hash(password));
            int newRocordId = (int)sqlCommand.ExecuteScalar();
            RegisterUser(login, newRocordId);
        }

        private void btnAuthenticate_Click(object sender, EventArgs e)
        {
            string name = tbLogin.Text;
            string pass = tbPassword.Text;
            Authenticate(name, pass);
        }



        private void EnableDisableBut()
        {
            btnAuthenticate.Enabled = tbLogin.Text.Length >= 3 && tbPassword.Text.Length >= 3;
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            EnableDisableBut();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            EnableDisableBut();
        }



        private void btCreateES_Click(object sender, EventArgs e)
        {
            var createES_form = new Application();
            DialogResult dResult = createES_form.ShowDialog();
        }

        private void btnEditES_Click(object sender, EventArgs e)
        {
            if (lvExpertSystems.SelectedItems.Count == 0) return;

            int selectedEsId = lvExpertSystems.SelectedItems[0].Index + 1;
            var createES_form = new Application(selectedEsId);
            DialogResult dResult = createES_form.ShowDialog();
        }




        SocketClient connectionToServer;
        private IPAddress ipAddress;
        private string strPortInput = "23000";

        private void btnConsultation_Click(object sender, EventArgs e)
        {
            connectionToServer = new SocketClient(ipAddress, 23000);
            Task.Run(() => connectionToServer.ConnectToServer(valueGetEvent));

            var consultationForm = new ConsultationForm(this.ES_id, connectionToServer, memory, expertSystem, this);
            expertSystem.InitES(consultationForm);
            DialogResult dResult = consultationForm.ShowDialog();

            if (connectionToServer.IsConnected)
            {
                connectionToServer.CloseAndDisconnect();
            }
        }
    }
}
