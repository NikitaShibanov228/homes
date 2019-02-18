using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace auth
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginBut_Click(object sender, EventArgs e)
        {

            string logStr = loginBox.Text;
            string passStr = passwordBox.Text;
            string connStr = "server=localhost;user=root;database=user1;password=;";
            string sql = "SELECT log, pass FROM users";
            if (userCheck(connStr, sql, logStr, passStr))
            {
                MessageBox.Show("Успешно", "Успех");
                this.Visible = false;
                Queries qr = new Queries();
                qr.Show();
                
            } else
            {
                MessageBox.Show("НеУспешно", "НеУспех");
            }
            




        }



        bool userCheck (string connStr, string sqlCommand, string user, string pass)
        {
            
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlCommand, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // элементы массива [] - это значения столбцов из запроса SELECT
                    if ((user == reader[0].ToString()) & pass == reader[1].ToString())
                    {
                        reader.Close();  
                        conn.Close();
                        return true;
                    }
                }
                reader.Close(); // закрываем reader
                conn.Close();
                return false;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Исключение!");
            }
            return false;

        }
    }
}
