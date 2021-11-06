using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        DBConnector connector;
        SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            connector = new DBConnector(ConfigurationManager.ConnectionStrings["Local"].ConnectionString);
            connection = new SqlConnection();
        }

        private void connectbtn_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text.ToString() == "Connect")
            {
                connection = connector.Connect();
                connection.Open();
                MessageBox.Show("Opened", "Connection is Opened!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                (sender as Button).Text = "Disconnect";
            }
            else
            {
                connector.Disconnect(connection);
                MessageBox.Show("Closed", "Connection is Closed!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                (sender as Button).Text = "Connect";
                connection.ConnectionString = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "";
            DataTable data = new DataTable();
            if (connection.ConnectionString == "")
            {
                MessageBox.Show("Connect to Database First!");
                return;
            }
            switch ((sender as Button).Text)
            {
                case "GetStationaries":
                    query = "Select * from Stationaries";
                    break;
                case "GetTypes":
                    query = "Select * from Types";
                    break;
                case "GetManagers":
                    query = "Select * from Managers";
                    break;
                case "GetMostStats":
                    query = "Select distinct Name,Quantity from Stationaries where Quantity=(select max(Quantity) from Stationaries);";
                    break;
                case "GetLeastStats":
                    query = "Select distinct Name,Quantity from Stationaries where Quantity=(select min(Quantity) from Stationaries);";
                    break;
                case "GetMostPrice":
                    query = "Select distinct Name,Price from Stationaries where Price=(select max(Price) from Stationaries);";
                    break;
                case "GetLeastPrice":
                    query = "Select distinct Name,Price from Stationaries where Price=(select min(Price) from Stationaries);";
                    break;
            }
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {

                adapter.Fill(data);
            }
            dataGridView1.DataSource = data;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (connection.ConnectionString == "")
            {
                MessageBox.Show("Connect to Database First!");
                return;
            }
            if ((sender as Button).Text=="Add")
            {
                
                AddForm form = new AddForm(connection);
                form.ShowDialog();
                
            }
            else
            {
                Delete form = new Delete(connection);
                form.ShowDialog();
            }
        }
    }
}
