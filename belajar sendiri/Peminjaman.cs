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
    public partial class Peminjaman : Form
    {
        public Peminjaman()
        {
            InitializeComponent();
        }
       
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-638C77F;Initial Catalog=ppp;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        //int count;
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Peminjaman_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(+3);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Judul_Buku from Tbl_Buku";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    comboBox1.Items.Add(dr.GetString(i));
                }
            }
            dr.Close();
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        int count;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string eid = textBox1.Text;
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_User where Nama = '" + textBox1.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //

                cmd.CommandText = "select count (ID_Peminjaman) from Tbl_Peminjaman where Nama='" + textBox1.Text + "' ";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());

                //
                if (ds.Tables[0].Rows.Count != 0)
                {
                    textBox2.Text = ds.Tables[0].Rows[0][0].ToString();
                    textBox3.Text = ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    textBox1.Clear();
                    MessageBox.Show("Nama yang anda masukan salah", "Nama Salah", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (comboBox1.SelectedIndex != -1 && count <= 2)
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Tbl_Peminjaman (ID_Peminjaman,ID_User,Nama,Kode_Buku,Judul_Buku,Tanggal_Pinjam,Tanggal_Denda)values('AD" + PINJAMID.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" +dateTimePicker1.Text+ "','" + dateTimePicker2.Text + "')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "update Tbl_Buku set Stok = Stok -1 where Kode_Buku ='" + textBox5.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Meminjam Buku");
                    conn.Close();

                }
                else
                {
                    MessageBox.Show("Buku Sudah dipinjam");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Buku where Judul_Buku ='" + comboBox1.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            textBox5.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(+3);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
                
        }
    }
}
