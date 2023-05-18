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
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-S69NDOA\\SQLEXPRESS;Initial Catalog=personel;Integrated Security=True");
        private void frmistatistik_Load(object sender, EventArgs e)
        {   //toplam personel sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from table_1", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                label12.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //evli personel sayısı
            baglanti.Open();
            SqlCommand married = new SqlCommand("select count(*) from table_1 where perdurum=1",baglanti);
            SqlDataReader dr2 = married.ExecuteReader();
            while (dr2.Read())
            {
                label11.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //bekar personel sayısı
            baglanti.Open();
            SqlCommand marriedd = new SqlCommand("select count(*) from table_1 where perdurum=0", baglanti);
            SqlDataReader dr3 = married.ExecuteReader();
            while (dr3.Read())
            {
                label10.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //Şehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(persehir)) from table_1", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                label9.Text = dr4[0].ToString();
            }
            baglanti.Close();


            //toplam maas
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(permaas) from table_1", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                label8.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //ortalama maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(permaas) from table_1", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                label7.Text = dr6[0].ToString();
            }
            baglanti.Close();

        }
    }
}
