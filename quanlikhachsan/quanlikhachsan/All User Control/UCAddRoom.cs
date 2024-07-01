using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlikhachsan.All_User_Control
{
    public partial class UCAddRoom : UserControl
    {
        function fn = new function();
        String query;

        public UCAddRoom()
        {
            InitializeComponent();
        }

        private void UCAddRoom_Load(object sender, EventArgs e)
        {
            LoadRoomData();
        }

        public void LoadRoomData()
        {
            query = "SELECT * FROM rooms";
            DataSet ds = fn.GetData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                string roomno = txtRoomNo.Text;

                // Kiểm tra xem room number đã tồn tại trong cơ sở dữ liệu hay chưa
                query = "SELECT COUNT(*) FROM rooms WHERE roomNo = '" + roomno + "'";
                DataSet ds = fn.GetData(query);
                int count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                if (count > 0)
                {
                    MessageBox.Show("Room number already exists. Please choose a different room number.", "Duplicate Room Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    String type = txtType.Text;
                    String bed = txtBed.Text;
                    Int64 price = Int64.Parse(txtPrice.Text);

                    query = "INSERT INTO rooms (roomNo, roomType, bed, price) VALUES('" + roomno + "','" + type + "','" + bed + "'," + price + ")";
                    fn.setData(query, "Room Added.");

                    LoadRoomData(); // Reload data after successful addition
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("All fields are mandatory.", "Need to fill all the information !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void ClearFields()
        {
            txtRoomNo.Clear();
            txtType.ResetText();
            txtBed.ResetText();
            txtPrice.Clear();
        }
    }
}
