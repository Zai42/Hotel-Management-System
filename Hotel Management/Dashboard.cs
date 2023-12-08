using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Hotel_Management.Log_In;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Hotel_Management
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'room_info2.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter6.Fill(this.room_info2.Room_information);
            // TODO: This line of code loads data into the 'room_info.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter5.Fill(this.room_info.Room_information);
            // TODO: This line of code loads data into the 'login_Room_ID.Login' table. You can move, or remove it, as needed.
            this.loginTableAdapter.Fill(this.login_Room_ID.Login);
            // TODO: This line of code loads data into the 'room_information.Room_information' table. You can move, or remove it, as needed.
            this.room_informationTableAdapter4.Fill(this.room_information.Room_information);
            // TODO: This line of code loads data into the 'room_facilities.Room_facilities' table. You can move, or remove it, as needed.
            this.room_facilitiesTableAdapter.Fill(this.room_facilities.Room_facilities);
            // TODO: This line of code loads data into the 'hotelDataSet26.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter3.Fill(this.hotelDataSet26.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet24.Room_information' table. You can move, or remove it, as needed.
            // this.room_informationTableAdapter2.Fill(this.hotelDataSet24.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet25.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter1.Fill(this.hotelDataSet25.Room_information);
            // TODO: This line of code loads data into the 'hotelDataSet19.Room_information' table. You can move, or remove it, as needed.
            //this.room_informationTableAdapter.Fill(this.hotelDataSet19.Room_information);

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected in the ListBox control
            if (listBox1.SelectedItem != null)
            {
                // Get the selected item from the ListBox control
                string selectedItem = listBox1.SelectedItem.ToString();

                // Create a new DataTable to store the filtered data
                DataTable filteredData = new DataTable();

                // Loop through all the columns in the dataset
                for (int i = 0; i < room_facilities.Tables[0].Columns.Count; i++)
                {
                    // If the column is in front of the selected item, add it to the filteredData DataTable
                    if (room_facilities.Tables[0].Columns[i].ColumnName.ToLower() == selectedItem.ToLower())
                    {
                        break;
                    }
                    filteredData.Columns.Add(room_facilities.Tables[0].Columns[i].ColumnName);
                }

                foreach (DataRowView rowView in listBox1.SelectedItems)
                {
                    DataRow row = rowView.Row;
                    DataRow newRow = filteredData.NewRow();
                    bool rowAdded = false;
                    for (int i = 0; i < filteredData.Columns.Count; i++)
                    {
                        if (filteredData.Columns[i].ColumnName == selectedItem)
                        {
                            newRow[selectedItem] = row[selectedItem];
                            rowAdded = true;
                        }
                        else if (!rowAdded)
                        {
                            newRow[filteredData.Columns[i].ColumnName] = row[filteredData.Columns[i].ColumnName];
                        }
                    }
                    filteredData.Rows.Add(newRow);
                }

                dataGridView1.DataSource = filteredData;


                // Get the rooms available for the selected room type
                string room_type = listBox1.GetItemText(listBox1.SelectedItem);

                DataRow[] filteredRows = room_information.Tables["Room_information"].Select("room_type='" + room_type + "'" + " AND booked IS NULL");

                if (filteredRows.Length > 0)
                {
                    DataTable filteredTable = filteredRows.CopyToDataTable();
                    listBox2.DisplayMember = "Room_ID";
                    listBox2.ValueMember = "Room_ID";
                    listBox2.DataSource = filteredTable;
                }
                else
                {
                    listBox2.DataSource = null;
                }
                // Displaying data in datagridview2
                // Get the selected room type
                string selectedRoomType = listBox1.GetItemText(listBox1.SelectedItem);

                // Create a new DataTable to store the filtered data
                DataTable filteredTable2 = new DataTable();
                filteredTable2.Columns.Add("Room_ID", typeof(string));
                filteredTable2.Columns.Add("Room_floor", typeof(string));
                filteredTable2.Columns.Add("Rent", typeof(string));
                filteredTable2.Columns.Add("booked", typeof(string));
                filteredTable2.Columns.Add("Total Occupancy", typeof(string));

                // Filter the rows based on the selected room type
                DataRow[] filteredRows2 = room_information.Tables["Room_information"].Select($"[room_type] = '{selectedRoomType}'");

                // Add the filtered rows to the DataTable
                foreach (DataRow row in filteredRows)
                {
                    filteredTable2.Rows.Add(row["Room_ID"], row["Room_floor"], row["Rent"], row["booked"], row["Total Occupancy"]);
                }

                // Set the filtered DataTable as the DataSource of DataGridView2
                dataGridView2.DataSource = filteredTable2;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Room_ID = listBox2.SelectedItem.ToString();

            DateTime checkInDate = dateTimePicker1.Value;
            DateTime checkOutDate = dateTimePicker2.Value;

            string email = UserCredentials.Email;
            string passward = UserCredentials.Passward;

            // Connection string to your database
            string connectionString = "Data Source=MRZEE\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True";

            // Email and username of the logged-in user


            // SQL query to retrieve the row for the logged-in user
            string query = $"SELECT * FROM Login WHERE EmailAdress = '{email}' AND passward = '{passward}'";

            // Create a SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the database connection
                connection.Open();

                // Create a SqlCommand object with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and get the SqlDataReader object
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the rows returned by the query
                        while (reader.Read())
                        {
                            // Access the values in the row using the column names or indexes
                            int roomIdOrdinal = reader.GetOrdinal("Room_ID");
                            string roomId2 = null;

                            if (!reader.IsDBNull(roomIdOrdinal))
                              {
                                 roomId2 = reader.GetString(roomIdOrdinal);
                               }
                            
                            object checkInDateObj = reader["Checkin_Date"];
                            DateTime? checkinDate = null;
                            if (checkInDateObj != DBNull.Value)
                            {
                                checkinDate = (DateTime)checkInDateObj;
                            }

                            object checkOutDateObj = reader["Checkout_Date"];
                            DateTime? checkoutDate = null;
                            if (checkInDateObj != DBNull.Value)
                            {
                                checkoutDate = (DateTime)checkOutDateObj;
                            }
                        }
                    }
                }
            }


            // Update the room ID, check-in date, and check-out date columns
            // with the values obtained above
            // ...
            // Retrieve the row for the logged-in user
            string connectionString2 = "Data Source=MRZEE\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True";
            using (SqlConnection connection2 = new SqlConnection(connectionString2))
            {
                string sql = "SELECT * FROM Login";

                // Create a SqlDataAdapter object
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString2);

                // Create a SqlCommandBuilder object
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                // Create a DataTable to hold the data
                DataTable userTable2 = new DataTable();

                // Fill the DataTable with the data from the database
                adapter.Fill(userTable2);

                DataRow[] userRows = userTable2.Select($"EmailAdress = '{email}' AND [passward] = '{passward}'");

                if (userRows.Length > 0)
                {
                    // Update the room ID, check-in date, and check-out date columns with the values obtained above
                    DataRow userRow = userRows[0];
                    userRow["Room_ID"] = Room_ID;
                    userRow["Checkin_Date"] = checkInDate;
                    userRow["Checkout_Date"] = checkOutDate;


                    adapter.Update(userTable2);
                }
                else
                {
                    // Handle the case where the logged-in user is not found
                    MessageBox.Show("User not found");
                }
            }
            string connectionString3 = "Data Source=MRZEE\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True";

            using (SqlConnection connection3 = new SqlConnection(connectionString3))
            {
                // Define the SQL query
                string sql2 = "SELECT * FROM Room_Information";

                // Create a SqlDataAdapter object
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, connection3);

                // Create a SqlCommandBuilder object
                SqlCommandBuilder builder2 = new SqlCommandBuilder(adapter2);

                // Create a DataTable to hold the data
                DataTable userTable3 = new DataTable();

                // Fill the DataTable with the data from the database
                adapter2.Fill(userTable3);

                DataRow[] userRows2 = userTable3.Select($"Room_ID = '{Room_ID}'");

                if (userRows2.Length > 0)
                {
                    // Update the room ID, check-in date, and check-out date columns with the values obtained above
                    DataRow userRow2 = userRows2[0];
                    userRow2["Room_ID"] = Room_ID;


                    adapter2.Update(userTable3);
                }
                else
                {
                    // Handle the case where the logged-in user is not found
                    MessageBox.Show("Room not found");
                }
                // Save the changes to the database
                // ...
                // Define the SQL query
            }
        }
    




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
