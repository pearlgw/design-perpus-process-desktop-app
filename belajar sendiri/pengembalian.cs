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

namespace belajar_sendiri
{
    public partial class pengembalian : Form
    {
        public pengembalian()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-638C77F;Initial Catalog=ppp;Integrated Security=True");

        void dg()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Tbl_Peminjaman.ID_Peminjaman,Tbl_Peminjaman.Nama,Tbl_Peminjaman.ID_User,Tbl_Peminjaman.Kode_Buku,Tbl_Peminjaman.Judul_Buku,Tbl_Peminjaman.Tanggal_Denda,Tbl_Pengembalian.Tanggal_Kembali from Tbl_Peminjaman left join Tbl_Pengembalian on Tbl_Peminjaman.ID_Peminjaman=Tbl_Pengembalian.ID_Peminjaman where Tbl_Peminjaman.ID_User='" + textBox1.Text + "' and Tbl_Pengembalian.Tanggal_Kembali is null ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Tbl_Peminjaman.ID_Peminjaman,Tbl_Peminjaman.Nama,Tbl_Peminjaman.ID_User,Tbl_Peminjaman.Kode_Buku,Tbl_Peminjaman.Judul_Buku,Tbl_Peminjaman.Tanggal_Denda,Tbl_Pengembalian.Tanggal_Kembali from Tbl_Peminjaman left join Tbl_Pengembalian on Tbl_Peminjaman.ID_Peminjaman=Tbl_Pengembalian.ID_Peminjaman where Tbl_Peminjaman.ID_User='" + textBox1.Text + "' and Tbl_Pengembalian.Tanggal_Kembali is null ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Nama yang anda masukan salah");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                KodeBox.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                NamaBox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                IDBox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                kodebukuBOX.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                JudulBukuBo.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                pinjamdt.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                DateTime tanggal1 = Convert.ToDateTime(dateTimePicker1.Text);
                DateTime tanggal2 = Convert.ToDateTime(pinjamdt.Text);
                TimeSpan ts = new TimeSpan();
                ts = tanggal1.Subtract(tanggal2);
                TElatBox.Text = ts.Days + "";
                int hari = Int32.Parse(TElatBox.Text);
                if (hari > 0)
                {
                    double denda = 3000;
                    double total = hari * denda;
                    DEndaBOx.Text = total.ToString("Rp #");
                }
                else
                {
                    TElatBox.Clear();
                    MessageBox.Show("Tidak Ada Denda !!!");
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void NamaBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void IDBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void kodebukuBOX_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void JudulBukuBo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pinjamdt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Tbl_Pengembalian (ID_Peminjaman,ID_User,Nama,Kode_Buku,Judul_Buku,Tanggal_Kembali,Denda)values('" + KodeBox.Text + "','" + IDBox.Text + "','" + NamaBox.Text + "','" + kodebukuBOX.Text + "','" + JudulBukuBo.Text + "','" + dateTimePicker1.Text + "','" + DEndaBOx.Text + "')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "update Tbl_Buku set Stok = Stok +1 where Judul_Buku ='" + JudulBukuBo.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Berhasil Mengembalikan Buku");
            dg();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {

                KodeBox.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                NamaBox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                IDBox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                kodebukuBOX.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                JudulBukuBo.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                pinjamdt.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                DateTime tanggal1 = Convert.ToDateTime(dateTimePicker1.Text);
                DateTime tanggal2 = Convert.ToDateTime(pinjamdt.Text);
                TimeSpan ts = new TimeSpan();
                ts = tanggal1.Subtract(tanggal2);
                TElatBox.Text = ts.Days + "";
                int hari = Int32.Parse(TElatBox.Text);
                if (hari > 0)
                {
                    double denda = 3000;
                    double total = hari * denda;
                    DEndaBOx.Text = total.ToString("Rp #");
                }
                else
                {
                    TElatBox.Clear();
                    MessageBox.Show("Tidak Ada Denda !!!");
                }
            }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void pinjamdt_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void pengembalian_Load(object sender, EventArgs e)
        {

        }
    }
}
