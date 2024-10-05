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

namespace PROJE_SQL_DB_udemy
{
    public partial class frmkategoriler : Form
    {
        public frmkategoriler()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into tblkategori (kategoriad,kategoriid) values (@p1,@p2)",baglanti);
            
            komut2.Parameters.AddWithValue("@p1",txtkategoriad.Text);
            komut2.Parameters.AddWithValue("@p2",txtkategoriid.Text);
            komut2.ExecuteNonQuery();
            
            baglanti.Close();
            MessageBox.Show("kategori kaydetme işlemi başarıyla gerçekleşti");

        }
        SqlConnection baglanti=new SqlConnection(@"Data Source=ENES;Initial Catalog=satisVT;Integrated Security=True;");

        private void btnlistele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tblkategori", baglanti);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt= new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkategoriid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkategoriad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Delete From tblkategori where kategoriid=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1",txtkategoriid.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kategori silme işlemi gerçekleşti.");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update tblkategori set kategoriad=@p1 where kategoriid=@p2", baglanti);
            komut4.Parameters.AddWithValue("@p1", txtkategoriad.Text);
            komut4.Parameters.AddWithValue("@p2", txtkategoriid.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kategori güncellem işlemi gerçekleşti.");

        }
    }
}
