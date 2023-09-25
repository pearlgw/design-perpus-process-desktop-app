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
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace belajar_sendiri
{
    public partial class lihatBuku : Form
    {
        public lihatBuku()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-638C77F;Initial Catalog=ppp;Integrated Security=True");
        string imglocation;
        public void tampil()
        {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [Tbl_Buku]";
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
            cmd.CommandText = "Select * from [Tbl_Buku] where Judul_buku = '" + textBox1.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            textBox1.Text = "";
        }

        public void clear()
        {
            textBox6.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            pictureBox1.Image = null;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)| *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imglocation;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void lihatBuku_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from[Tbl_Buku] where Kode_Buku = '" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            tampil();
            MessageBox.Show("Data berhasil dihapuskan");
            clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream streem = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [Daftar_buku] set Kode_Buku='" + this.textBox2.Text + "',Judul_buku='" + this.textBox3.Text + "',Penulis='" + this.textBox4.Text + "',Penerbit='"+this.textBox5.Text+"',Kategori='" + this.textBox8.Text + "',Lokasi='" + textBox7.Text + "',Stok='" + textBox6.Text + "',Sampul=@images where Kode_Buku='" + this.textBox2.Text + "'";
            cmd.Parameters.Add(new SqlParameter("@images", images));
            cmd.ExecuteNonQuery();
            conn.Close();
            tampil();
            MessageBox.Show("Data berhasil diubah");
            clear();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox2.Text = row.Cells["Kode_Buku"].Value.ToString();
            textBox3.Text = row.Cells["Judul_buku"].Value.ToString();
            textBox4.Text = row.Cells["Penulis"].Value.ToString();
            textBox5.Text = row.Cells["Penerbit"].Value.ToString();
            textBox6.Text = row.Cells["Stok"].Value.ToString();
            textBox7.Text = row.Cells["Lokasi"].Value.ToString();
            textBox8.Text = row.Cells["Kategori"].Value.ToString();
            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[7].Value);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)| *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imglocation;
            }
        }
    }
}
