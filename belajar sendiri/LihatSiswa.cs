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
    public partial class LihatSiswa : Form
    {
        public LihatSiswa()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-638C77F;Initial Catalog=ppp;Integrated Security=True");
        void clear()
        {
            UsernameBox.Clear();
            NamaBox.Clear();
            AlamatBOX.Clear();
            NISBox.Clear();
            PasswordBox.Clear();
        }
      

        public void tampil()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_User where role =  'Siswa  '";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void LihatSiswa_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [Tbl_User] where Nama = '" + textBox1.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [Tbl_User] set Nama='" + this.NamaBox.Text + "',ID_User='" + this.NISBox.Text + "',Alamat='" + this.AlamatBOX.Text + "',Username='" + this.UsernameBox.Text + "',Password ='" +this.PasswordBox.Text + "' where Id_User = '"+NISBox.Text+"'" ;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data berhasil diubah");
            clear();
            tampil();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [Tbl_User] where Nama= '" + NamaBox.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            tampil();
            MessageBox.Show("Data berhasil dihapuskan");
            clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                NISBox.Text = row.Cells["ID_User"].Value.ToString();
                NamaBox.Text = row.Cells["Nama"].Value.ToString();
                AlamatBOX.Text = row.Cells["Alamat"].Value.ToString();
                UsernameBox.Text = row.Cells["Username"].Value.ToString();
                PasswordBox.Text = row.Cells["Password"].Value.ToString();

            }
            catch (Exception X)
            { MessageBox.Show(X.ToString()); }
        }
    }
}
