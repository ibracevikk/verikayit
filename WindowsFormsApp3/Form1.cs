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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-S69NDOA\\SQLEXPRESS;Initial Catalog=personel;Integrated Security=True");

        void temizle()
        {
            txtid.Text = "";
            txtsoyad.Text = "";
            txtad.Text = "";
            txtmeslek.Text = "";
            maskedTextBox1.Text = "";
            comboBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtid.Focus();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.table_1TableAdapter.Fill(this.personelDataSet.Table_1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.table_1TableAdapter.Fill(this.personelDataSet.Table_1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into table_1 (perad,persoyad,persehir,permaas,permeslek) values (@p1,@p2,@p3,@p4,@p5)",baglanti);
            komut.Parameters.AddWithValue("@p1" , txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
           // komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                label8.Text = "true";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "false";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("delete from table_1 where personelid=@k1", baglanti);
            sil.Parameters.AddWithValue("@k1", txtid.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (label8.Text=="true")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "false")
            {
                radioButton2.Checked = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand edit = new SqlCommand("update table_1 set perad=@a1,persoyad=@a2,persehir=@a3,perdurum=@a4,permaas=@a5,permeslek=@a6 where personelid=@a7", baglanti);
            edit.Parameters.AddWithValue("@a1", txtad.Text);
            edit.Parameters.AddWithValue("@a2", txtsoyad.Text);
            edit.Parameters.AddWithValue("@a3", comboBox1.Text);
            edit.Parameters.AddWithValue("@a4", label8.Text);
            edit.Parameters.AddWithValue("@a5", maskedTextBox1.Text);
            edit.Parameters.AddWithValue("@a6", txtmeslek.Text);
            edit.Parameters.AddWithValue("@a7",txtid.Text);
            edit.ExecuteNonQuery();
            baglanti.Close();


           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmistatistik fr = new frmistatistik();
            fr.Show();
        }
    }
}
