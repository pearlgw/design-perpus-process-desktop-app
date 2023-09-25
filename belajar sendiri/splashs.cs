using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace belajar_sendiri
{
    public partial class splashs : Form
    {
        public splashs(string role)
        {
            
            InitializeComponent();
            label3.Text = role;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 40;
            if (panel2.Width >= 737)
            {
                timer1.Stop();
                Dashboard dsb = new Dashboard(label3.Text);
                dsb.Show();
                this.Hide();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
