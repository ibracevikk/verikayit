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

namespace WindowsFormsApp3
{
    public partial class kullanıcı_girişi : Form
    {
        public kullanıcı_girişi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-S69NDOA\\SQLEXPRESS;Initial Catalog=personel;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            textBox1.Focus();
            SqlCommand komut9 = new SqlCommand("select * from table_2 where kullanciad=@p1 and sifre=@p2", baglanti);
            komut9.Parameters.AddWithValue("@p1", textBox1.Text);
            komut9.Parameters.AddWithValue("@p2", textBox2.Text);
            textBox1.Focus();
            SqlDataReader drr = komut9.ExecuteReader();
            if (drr.Read())
            {
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre");
            }
            baglanti.Close();
        }
    }
}
