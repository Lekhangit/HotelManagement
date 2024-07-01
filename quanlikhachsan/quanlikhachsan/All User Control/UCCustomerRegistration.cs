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
using static System.Collections.Specialized.BitVector32;

namespace quanlikhachsan.All_User_Control
{
    public partial class txt : UserControl
    {
        function fn = new function();
        String query;
        public txt()
        {
            InitializeComponent();
        }
        public void LoadRoomNumbers()
        {
            string query = "SELECT roomNo FROM rooms";
            SqlDataReader reader = fn.getForCombo(query);

            // Xóa các mục đã có trong ComboBox để tránh trùng lặp
            txtRoomNo.Items.Clear();

            // Duyệt qua các dòng dữ liệu và thêm roomNo vào ComboBox
            while (reader.Read())
            {
                txtRoomNo.Items.Add(reader["roomNo"].ToString());
            }
            reader.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtRoom_Load(object sender, EventArgs e)
        {
            LoadRoomNumbers();
        }

        public void setComboBox(String query, ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            query = "select roomNo from rooms where bed = '" + txtbed.Text + "' and roomType ='" + txtRoom.Text + "' and booked = 'NO'";

        }

        private void txtbed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoom.SelectedIndex = -1;
        
        }
        //int rid;
        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có ít nhất một phần tử đã được chọn
            if (txtRoomNo.SelectedIndex != -1)
            {
                string selectedRoomNo = txtRoomNo.SelectedItem.ToString();

                // Tạo câu truy vấn SQL với roomNo được chọn từ ComboBox
                string query = "SELECT price, roomid, bed, roomType FROM rooms WHERE roomNo = '" + selectedRoomNo + "' and booked = 'NO'";

                // Thực hiện câu truy vấn và cập nhật các điều khiển trên giao diện
                DataSet ds = fn.GetData(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Lấy dữ liệu từ DataSet và hiển thị trên các điều khiển tương ứng
                    txtPrice.Text = ds.Tables[0].Rows[0]["price"].ToString();
                    txtroomid.Text = ds.Tables[0].Rows[0]["roomid"].ToString();
                    txtbed.Text = ds.Tables[0].Rows[0]["bed"].ToString();
                    txtRoom.Text = ds.Tables[0].Rows[0]["roomType"].ToString();
                 

                }
                else
                {
                    // Xử lý trường hợp không tìm thấy phòng
                    MessageBox.Show("Room not found or already booked!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnAlloteRoom_Click(object sender, EventArgs e)
        {
            // Tiếp tục với quá trình xử lý như bình thường
            if (txtName.Text != "" && txtContact.Text != "" && txtNationality.Text != "" && txtGender.Text != "" && txtDob.Text != "" && txtIdProof.Text != "" && txtAdress.Text != "" && txtCheckin.Text != "" && txtPrice.Text != "")
            {
                string cname = txtName.Text;
                Int64 mobile = Int64.Parse(txtContact.Text);
                string national = txtNationality.Text;
                string gender = txtGender.Text;
                string dob = txtDob.Text;
                string idproof = txtIdProof.Text;
                string adress = txtAdress.Text;
                string checkin = txtCheckin.Text;
                int rid = int.Parse(txtroomid.Text);

                // Kiểm tra xem idproof và mobile đã tồn tại trong cơ sở dữ liệu hay chưa
                string checkDuplicateQuery = "SELECT COUNT(*) FROM customer WHERE idproof = '" + idproof + "' OR mobile = " + mobile;
                int count = fn.getScalar(checkDuplicateQuery);

                // Kiểm tra xem có bất kỳ bản ghi nào chứa idproof hoặc mobile đã nhập hay không
                if (count > 0)
                {
                    MessageBox.Show("Duplicate entry found. A customer with the same ID Proof or Mobile already exists in the database.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Tạo câu lệnh INSERT để chèn dữ liệu vào bảng customer
                    string insertQuery = "INSERT INTO customer (cname, mobile, nationality, gender, dob, idproof, adress, checkin, roomid) VALUES ('" + cname + "', " + mobile + ", '" + national + "', '" + gender + "', '" + dob + "', '" + idproof + "', '" + adress + "', '" + checkin + "', " + rid + ")";

                    // Tạo câu lệnh UPDATE để cập nhật trạng thái booked của phòng trong bảng rooms
                    string updateQuery = "UPDATE rooms SET booked = 'YES' WHERE roomNo = '" + txtRoomNo.Text + "'";
                   
                    // Thực hiện các câu lệnh SQL một cách riêng biệt
                    fn.setData(insertQuery, "Room allocation successful.");
                    fn.setData(updateQuery, "Room status updated.");
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("All fields are mandatory.", "Need to fill all the information !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void txtrid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtroomid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
        private void ClearAll()
        {
            txtroomid.Clear();
            txtCheckin.ResetText();
            txtAdress.Clear();
            txtIdProof.Clear();
            txtDob.ResetText();
            txtGender.ResetText();
            txtNationality.Clear();
            txtContact.Clear();
            txtName.Clear();
            txtbed.ResetText();
            txtRoom.ResetText();
            txtPrice.ResetText();
            txtRoomNo.ResetText();

        }
    }
}
