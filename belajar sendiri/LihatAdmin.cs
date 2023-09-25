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
    public partial class LihatAdmin : Form
    {
        public LihatAdmin()
        {
            InitializeComponent();
        }
        void clear(){
        textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-638C77F;Initial Catalog=ppp;Integrated Security=True");
        void dg()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Tbl_User where Role ='Admin'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void LihatAdmin_Load(object sender, EventArgs e)
        {
            dg();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [Tbl_User] where Nama ='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
           
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete * from Tbl_user where Nama = '" + textBox3.Text + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                clear();
                dg();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [Tbl_User] set Nama='" + this.textBox3.Text + "',ID_User='" + this.textBox2.Text + "',Alamat='" + this.textBox4.Text + "',Username='" + this.textBox5.Text + "',Password ='" + textBox6.Text + "' where ID_User ='" + this.textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data berhasil diubah");
            clear();
            dg();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow Row = this.dataGridView1.Rows[e.RowIndex];
                textBox2.Text = Row.Cells["ID_User"].Value.ToString();
                textBox3.Text = Row.Cells["Nama"].Value.ToString();
                textBox4.Text = Row.Cells["Alamat"].Value.ToString();
                textBox5.Text = Row.Cells["Username"].Value.ToString();
                textBox6.Text = Row.Cells["Password"].Value.ToString();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }
    }
}
