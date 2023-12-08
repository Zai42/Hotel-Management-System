using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Hotel_Management
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            numericUpDown1.Value = numericUpDown1.Minimum;
        }
        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            // Check if the textbox contains any non-numeric characters
            if (textBox5.Text.Any(c => !char.IsDigit(c) && c != '+') || (textBox5.Text.Length >= 14))
            {
                // If the textbox contains non-numeric characters, show an error message to the user
                MessageBox.Show("Please enter only numerical values with Limit(13) in the phone number field.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Remove the last entered character from the textbox
                textBox5.Text = textBox5.Text.Remove(textBox5.Text.Length - 1);
                textBox5.SelectionStart = textBox5.Text.Length;
            }
 
        }
        private string GetSelectedGender()
        {
            if (radioButton1.Checked)
            {
                return "Male";
            }
            else if (radioButton2.Checked)
            {
                return "Female";
            }
            else if (radioButton3.Checked)
            {
                return "Other";
            }
            return string.Empty;
        }

        private bool IsValidEmail(string email)
        {
            // Define a regular expression for email validation
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);

            // Check if the email matches the regular expression
            if (regex.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter your first name", "Empty Text Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please enter your valid phone number", "Empty Text Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
                return;
            }
            if (!IsValidEmail(textBox6.Text))
            {
                MessageBox.Show("Invalid email address.");
                textBox6.Focus();
                return;
            }
            if (textBox3.Text.Length < 5)
            {
                MessageBox.Show("Very Short Passward");
                textBox3.Focus();
                return;
            }
            if (textBox5.Text.Length < 11)
            {
                MessageBox.Show("Phone number is very short!");
                textBox5.Focus();
                return;
            }
            int age;

            // Try to parse the age entered by the user
            if (!int.TryParse(numericUpDown1.Text, out age))
            {
                // If the age is not a valid integer, show an error message and clear the control
                MessageBox.Show("Please enter a valid age.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown1.Value = 0;
                numericUpDown1.Focus();
                return;
            }

            // Check if the age is less than 18
            if (age < 18)
            {
                // If it is less than 18, show an error message and clear the control
                MessageBox.Show("You need to be at least 18 years old to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown1.Value = 0;
                numericUpDown1.Focus();
                return;
            }


            SqlConnection cobj = new SqlConnection("Data Source=MRZAI\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True");
            cobj.Open();
            string query = "INSERT INTO Login (FirstName, LastName, Gender, Age,PhoneNumber,EmailAdress,passward) VALUES (@val1, @val2, @val3, @val4, @val5, @val6, @val7)";
            using (SqlCommand command = new SqlCommand(query, cobj))
            {
                command.Parameters.AddWithValue("@val1", textBox1.Text);
                command.Parameters.AddWithValue("@val2", textBox2.Text);
                command.Parameters.AddWithValue("@val3", GetSelectedGender());
                command.Parameters.AddWithValue("@val4", numericUpDown1.Value);
                command.Parameters.AddWithValue("@val5", textBox5.Text);
                command.Parameters.AddWithValue("@val6", textBox6.Text);
                command.Parameters.AddWithValue("@val7", textBox3.Text);
                if (cobj.State != ConnectionState.Open)
                {
                    cobj.Open();
                }
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Information Receieved!");
                }
                else
                {
                    MessageBox.Show("Error in receiving information");
                }
                command.CommandTimeout = 120;
                command.Dispose();
            }
            if (cobj.State != ConnectionState.Closed)
            {
                cobj.Close();
            }

            this.Hide();
            Log_In obj = new Log_In();
            obj.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter passward", "Empty Text Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
         

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {   

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the minimum value to 14
            numericUpDown1.Minimum = 14;

            // Set the initial value to 14
            numericUpDown1.Value = 14;

            // Attach the ValueChanged event handler
            numericUpDown1.ValueChanged += new EventHandler(numericUpDown1_ValueChanged);
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
     
        }
    }

}

