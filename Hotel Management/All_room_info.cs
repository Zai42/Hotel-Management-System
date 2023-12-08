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

namespace Hotel_Management
{
    public partial class All_room_info : Form
    {
        public All_room_info()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void All_room_info_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hotelDataSet23.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter13.Fill(this.hotelDataSet23.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet22.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter12.Fill(this.hotelDataSet22.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet21.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter11.Fill(this.hotelDataSet21.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet20.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter10.Fill(this.hotelDataSet20.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet17.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter9.Fill(this.hotelDataSet17.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet16.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter8.Fill(this.hotelDataSet16.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet15.Room_information' table. You can move, or remove it, as needed.
            // this.room_informationTableAdapter7.Fill(this.hotelDataSet15.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet14.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter6.Fill(this.hotelDataSet14.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet13.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter5.Fill(this.hotelDataSet13.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet12.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter4.Fill(this.hotelDataSet12.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet11.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter3.Fill(this.hotelDataSet11.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet3.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter2.Fill(this.hotelDataSet3.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet2.Room_information' table. You can move, or remove it, as needed.
            // this.room_informationTableAdapter1.Fill(this.hotelDataSet2.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter.Fill(this.hotelDataSet.Room_information);
            // Create a new SQL connection
            
            SqlConnection conn = new SqlConnection("Data Source=MRZAI\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True");

            // Create a new SQL command
            SqlCommand cmd = new SqlCommand("SELECT * from Room_information", conn);

            // Create a new SQL data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Create a new data table to hold the results
            DataTable dt = new DataTable();

            // Fill the data table with the results of the query
            da.Fill(dt);

            // Add the data table to the data grid view
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.room_informationTableAdapter11.FillBy(this.hotelDataSet21.Room_information);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
