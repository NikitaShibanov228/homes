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
    public partial class Inserting : Form
    {
        public Inserting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string item = nameBox.Text;
            int value = Convert.ToInt32(valueBox.Text);
            string connStr = "server=localhost;user=root;database=users;password=;";
            string sql = $"INSERT INTO `products` (`name`, `left`) VALUES ('{item}',{value})";
            Ins(connStr, sql);

        }

        string Ins(string connStr, string sqlCommand)
        {
            string returnString = "";

            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlCommand, conn);
                command.ExecuteNonQuery();
                
                conn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Исключение!");
            }
            return returnString;

        }
    }
}
