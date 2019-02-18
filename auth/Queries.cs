using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace auth
{
    public partial class Queries : Form
    {
        public Queries()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string item = textBox1.Text;
            string connStr = "server=localhost;user=root;database=users;password=;";
            string sql = $"SELECT `name`, `left` FROM `products` WHERE `name` = '{item}'";
            listBox1.Items.Add(Sel(connStr, sql));
        }


        string Sel(string connStr, string sqlCommand)
        {
            string returnString = "";

            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlCommand, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // элементы массива [] - это значения столбцов из запроса SELECT
                    returnString = reader[1].ToString();
                }
                reader.Close(); // закрываем reader
                conn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Исключение!");
            }
            return returnString;

        }

        private void Queries_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inserting ins = new Inserting();
            ins.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Deleting del = new Deleting();
            del.Show();
        }
    }
}
