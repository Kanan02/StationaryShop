using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Delete : Form
    {
        SqlConnection _connection;
        public Delete(SqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "";

            switch ((sender as Button).Name)
            {
                case "button1":
                    query = $"DELETE FROM Stationaries WHERE Id={textBox1.Text};";
                    break;
                case "button2":
                    query = $"DELETE FROM Types WHERE Id={textBox2.Text};";
                    break;
                case "button3":
                    query = $"DELETE FROM Sales WHERE Id={textBox3.Text};";
                    break;
                case "button4":
                    query = $"DELETE FROM Managers WHERE Id={textBox4.Text};";
                    break;
                default:
                    break;
            }

            SqlCommand command = new SqlCommand(query, _connection);
            command.ExecuteNonQuery();
            MessageBox.Show("Success!");
        }
    }
}
