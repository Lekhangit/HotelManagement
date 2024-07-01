using quanlikhachsan.All_User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlikhachsan
{
    public partial class Dashbroad : Form
    {
        public Dashbroad()
        {
            InitializeComponent();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashbroad_Load(object sender, EventArgs e)
        {
            ucAddRoom1.Visible = false;
            ucCustomerRegistration1.Visible = false;
            ucCheckout1.Visible = false;
            ucCustomerDetail1.Visible = false;
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ucCustomerRegistration1.Visible = true;
            ucCustomerRegistration1.BringToFront();
            ucCustomerRegistration1.LoadRoomNumbers();


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ucAddRoom1.Visible = true;
            ucAddRoom1.BringToFront();
            ucAddRoom1.LoadRoomData();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ucCheckout1.Visible = true;
            ucCheckout1.BringToFront();
            ucCheckout1.UCCheckout_Load(sender, e);
        }

        private void ucCustomerDetail1_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ucCustomerDetail1.Visible = true;
            ucCustomerDetail1.BringToFront();
            ucCustomerDetail1.txtSearchBy_SelectedIndexChanged(sender, e);
        }
    }
}
