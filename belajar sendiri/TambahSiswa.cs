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
    public partial class TambahSiswa : Form
    {   
        public TambahSiswa()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-638C77F;Initial Catalog=ppp;Integrated Security=True");

        public void reset()
        {
            NamaBox.Text = "";
            NISbox.Text = "";
            AlamatBOX.Text = "";
            UsernameBOX.Text = "";
            PasswordBOX.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btsSave_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Tbl_User](ID_User,Nama,Alamat,Username,Password,Role) values ('" + NISbox.Text + "','" + NamaBox.Text + "','" + AlamatBOX.Text + "','" + UsernameBOX.Text + "','" + PasswordBOX.Text + "','Siswa')";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("data berhasil di inputkan");
            reset();
        }

        private void TambahSiswa_Load(object sender, EventArgs e)
        {
            reset();
        }
    }
}
