using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace belajar_sendiri
{
    public partial class Dashboard : Form
    {
        public Dashboard(string role)
        {

            InitializeComponent();
            customizeDesing();
            label6.Text = role;
        }

        private void customizeDesing()
        {
            panelSiswa.Visible = false;
            panelPetugas.Visible = false;
            paneladmin.Visible = false;
            panelBuku.Visible = false;
        }
        private void hideSubmenu()
        {
            if (panelSiswa.Visible == true)
                panelSiswa.Visible = false;
            if (panelPetugas.Visible == true)
                panelPetugas.Visible = false;
            if (paneladmin.Visible == true)
                paneladmin.Visible = false;
            if (panelBuku.Visible == true)
                panelBuku.Visible = false;
        }
        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else subMenu.Visible = false;
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelUtama.Controls.Add(childForm);
            panelUtama.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelChildForm.Text = childForm.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelSiswa_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSiswa_Click_1(object sender, EventArgs e)
        {
            showSubmenu(panelSiswa);
        }

        private void btnTambahSiswa_Click_1(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new TambahSiswa());
        }

        private void btnLihatSiswa_Click_1(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new LihatSiswa());
        }

        private void btnPetugas_Click_1(object sender, EventArgs e)
        {
            showSubmenu(panelPetugas);
        }

        private void btnTambahPetugas_Click_1(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new tambahPetugas());
        }

        private void btnLihatPetugas_Click_1(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new LihatPetugas());
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            showSubmenu(paneladmin);
        }

        private void btnTambahAdmin_Click_1(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new TambahAdmin());
        }

        private void btnLihatAdmin_Click_1(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new LihatAdmin());
        }

        private void btnBuku_Click_1(object sender, EventArgs e)
        {
            showSubmenu(panelBuku);
        }

        private void btnTambahBuku_Click_1(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new TambahBuku());
        }

        private void btnLihatBuku_Click_1(object sender, EventArgs e)
        {
            hideSubmenu();
            openChildForm(new lihatBuku());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //if (Login.loginuser != null)
            //{
            //    label6.Text = Login.loginuser;
            //}
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }

        private void btnPeminjamanAct_Click(object sender, EventArgs e)
        {
            openChildForm(new Peminjaman());
        }

        private void btnPengembalianAct_Click(object sender, EventArgs e)
        {
            openChildForm(new pengembalian());
        }

        private void btnPeminjamanRe_Click(object sender, EventArgs e)
        {
            openChildForm(new laporanPeminjaman());
        }

        private void btnPengembalianRe_Click(object sender, EventArgs e)
        {
            openChildForm(new LaporanPengembalian());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new Home());
        }

        
        private void labelStatus_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {
            if (label6.Text=="Petugas")
            {
                btnAdmin.Hide();
            }
            else if (label6.Text=="Siswa")
            {
                button21.Hide();
                button2.Hide();
                btnSiswa.Hide();
                btnAdmin.Hide();
                btnPetugas.Hide();
                btnTambahBuku.Hide();
                btnPeminjamanRe.Hide();
                btnPengembalianRe.Hide();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
