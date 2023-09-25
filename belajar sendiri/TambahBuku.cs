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

namespace belajar_sendiri
{
    public partial class TambahBuku : Form
    {
        public TambahBuku()
        {
            InitializeComponent();
        }

        void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            pictureBox1.Image = null;
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-638C77F;Initial Catalog=ppp;Integrated Security=True");
        string imagelocation;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG files(*.png)|*.png|JPG files(*.jpg)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagelocation = ofd.FileName.ToString();
                pictureBox1.ImageLocation = imagelocation;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && pictureBox1.Image != null)
            {
                byte[] images = null;
                FileStream streem = new FileStream(imagelocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(streem);
                images = brs.ReadBytes((int)streem.Length);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert Into Tbl_Buku (Kode_Buku,Judul_Buku,Penulis,Penerbit,Kategori,Lokasi,Stok,Sampul) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "',@images)";
                cmd.Parameters.Add(new SqlParameter("@images", images));
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("data Berhasil ditambahkan");
                clear();
            }
            else
            {
                MessageBox.Show("Lengkapi data terlebih dahulu");
            }
        }

        private void TambahBuku_Load(object sender, EventArgs e)
        {

        }
    }
}
