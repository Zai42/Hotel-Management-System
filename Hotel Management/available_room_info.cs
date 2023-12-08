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
    public partial class available_room_info : Form
    {
        public available_room_info()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home obj = new Home();
            obj.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void available_room_info_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hotelDataSet24.Room_information' table. You can move, or remove it, as needed.
            this.room_informationTableAdapter9.Fill(this.hotelDataSet24.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet10.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter8.Fill(this.hotelDataSet10.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet9.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter7.Fill(this.hotelDataSet9.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet8.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter6.Fill(this.hotelDataSet8.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet7.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter5.Fill(this.hotelDataSet7.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet5.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter4.Fill(this.hotelDataSet5.Room_information);
            // TODO: This line of code loads data into the 'latest.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter3.Fill(this.latest.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter2.Fill(this.hotelDataSet.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet4.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter1.Fill(this.hotelDataSet4.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet1.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter.Fill(this.hotelDataSet.Room_information);
            SqlConnection cobj = new SqlConnection("Data Source=MRZEE\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True");
            cobj.Open();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM Room_information", cobj);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            DataView view = new DataView(table);
            view.RowFilter = "booked IS NUlL";
            dataGridView1.DataSource = view;
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.room_informationTableAdapter.FillBy(this.hotelDataSet1.Room_information);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.room_informationTableAdapter3.FillBy(this.latest.Room_information);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
