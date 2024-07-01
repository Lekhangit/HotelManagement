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
    public partial class UCCustomerDetail : UserControl
    {
        function fn = new function();
        string query;
        public UCCustomerDetail()
        {
            InitializeComponent();
        }

        public void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.SelectedIndex == 0) 
            {
                query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.adress, customer.checkin, customer.checkout, rooms.roomNo,rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid";
                DataSet ds = fn.GetData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
