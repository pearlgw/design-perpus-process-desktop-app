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
    public partial class TambahAdmin : Form
    {
        public TambahAdmin()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-638C77F;Initial Catalog=ppp;Integrated Security=True");

        void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Tbl_User (ID_User,Nama,Alamat,Username,Password,Role) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','Admin')";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data berhasil disimpan");
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
