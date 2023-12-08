using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Hotel_Management
{
    public partial class Log_In : Form
    {
        public Log_In()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }
        public static class UserCredentials
        {
            public static string Email { get; set; }
            public static string Passward { get; set; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cobj = new SqlConnection("Data Source=MRZAI\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True");
            cobj.Open();
            string query = string.Format("SELECT * FROM  Login WHERE EmailAdress = '"+textBox1.Text+"'AND passward='"+textBox2.Text+"'");
            SqlDataAdapter sda = new SqlDataAdapter(query, cobj);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                UserCredentials.Email = textBox1.Text;
                UserCredentials.Passward = textBox2.Text;
                this.Hide();
                Dashboard a_room = new Dashboard();
                a_room.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Passward", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
  
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
