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
    public partial class AddForm : Form
    {
        SqlConnection _connection;
        public AddForm(SqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;
        }

        private void statbtn_Click(object sender, EventArgs e)
        {
            string query = "";
            
            switch ((sender as Button).Name)
            {
                case "statbtn":
                    query= "INSERT INTO Stationaries (Name,TypeId,Price,Color,Quantity)" +
                    $"VALUES ('{textBox1.Text}',{textBox2.Text},{textBox3.Text},'{textBox4.Text}',{textBox5.Text});";
            
                    break;
                case "button1":
                    query = "INSERT INTO Types (Name,Quantity)" +
                    $"VALUES ('{textBox6.Text}',{textBox7.Text});";
                    break;
                case "button2":
                    query = "INSERT INTO Sales (NameOfCompany ,StationaryId,ManagerId,Date)" +
                       $"VALUES ('{textBox12.Text}',{textBox11.Text},{textBox10.Text},'{textBox9.Text}');";

                    break;
                case "button3":
                    query= "INSERT INTO Managers (FullName)" +
                        $"VALUES ('{textBox13.Text}');";  
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
