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

    public partial class UCCheckout : UserControl
    {
        function fn = new function();
        String query;
        public UCCheckout()
        {
            InitializeComponent();
        }

        public void UCCheckout_Load(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.adress,customer.checkin,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid = rooms.roomid";
            DataSet ds = fn.GetData(query);
            dataGridViewCout.DataSource = ds.Tables[0];
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.adress,customer.checkin,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid = rooms.roomid WHERE cname like '"+txtName.Text+"%'";
            DataSet ds = fn.GetData(query);
            dataGridViewCout.DataSource = ds.Tables[0];
        }
        int id;
        private void dataGridViewCout_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridViewCout.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtCName.Text = dataGridViewCout.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtRoom.Text = dataGridViewCout.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (dataGridViewCout.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int selectedRowIndex = dataGridViewCout.SelectedRows[0].Index;
                    id = int.Parse(dataGridViewCout.Rows[selectedRowIndex].Cells[0].Value.ToString());

                    String cdate = txtCheckOutDate.Text;
                    query = "DELETE FROM customer WHERE cid = " + id;
                    fn.setData(query, "Check out successfully.");

                    // Cập nhật trạng thái của phòng thành 'NO' sau khi check out thành công
                    string roomNo = dataGridViewCout.Rows[selectedRowIndex].Cells[9].Value.ToString(); 
                    query = "UPDATE rooms SET booked = 'NO' WHERE roomNo = '" + roomNo + "'";
                    fn.setData(query, "Room status updated successfully.");

                    UCCheckout_Load(this, null);
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to check out.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void ClearAll()
        {
            txtName.Clear();
            txtCName.Clear();
            txtRoom.Clear();
            txtCheckOutDate.ResetText();
        }

        private void dataGridViewCout_Leave(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
