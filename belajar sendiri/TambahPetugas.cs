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
    public partial class tambahPetugas : Form
    {
        public tambahPetugas()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-638C77F;Initial Catalog=ppp;Integrated Security=True");

        void clear()
        {
            AlamatBOX.Clear();
            USernameBOX.Clear();
            PasswordBOX.Clear();
            NamaBOX.Clear();
            IDBOX.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Tbl_User (ID_User,Nama,Alamat,Username,Password,Role)values ('" + IDBOX.Text + "','" + NamaBOX.Text + "','" + AlamatBOX.Text + "','" + USernameBOX.Text + "','" + PasswordBOX.Text + "','Petugas')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data berhasil ditambahkan");
            conn.Close();
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void tambahPetugas_Load(object sender, EventArgs e)
        {
            clear();
        }
    }
}
