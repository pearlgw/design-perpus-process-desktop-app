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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //public static string loginuser = "";
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-638C77F;Initial Catalog=ppp;Integrated Security=True");
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_User where Username = '" + txtBoxUser.Text + "' and Password = '" + txtBoxPass.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds);
            da.Fill(dt);

            if (ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Role"].ToString() == "Admin")
                    {
                        string adm = "Admin";
                        splashs sp = new splashs(adm);
                        sp.Show();
                        this.Hide();
                        //Dashboard dsb = new Dashboard(adm);

                    }
                    else if (dr["Role"].ToString() == "Petugas")
                    {
                        string pt = "Petugas";
                        this.Hide();
                        //Dashboard dsb = new Dashboard(pt);
                        splashs sp = new splashs(pt);
                        sp.Show();
                        
                    }
                    else if (dr["Role"].ToString() == "Siswa")
                    {
                        string sss = "Siswa";
                        this.Hide();
                        //Dashboard dsb = new Dashboard(sss);
                        splashs sp = new splashs(sss);
                        sp.Show();

                    }
                }
            }
            else
            {
                MessageBox.Show("Username / Password Salah !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
