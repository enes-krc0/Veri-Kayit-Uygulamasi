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
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnkategori_Click(object sender, EventArgs e)
        {
            frmkategoriler fr =new frmkategoriler ();
            fr.ShowDialog();
        }

        private void btnmusteri_Click(object sender, EventArgs e)
        {
            frmmusteri fr2=new frmmusteri ();
            fr2.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=ENES;Initial Catalog=satisVT;Integrated Security=True;");
        private void Form1_Load(object sender, EventArgs e)
        {
            //ürünlerin durum seviyesi
            SqlCommand komut = new SqlCommand("execute test4", baglanti);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;

            //grafige veri seçme+

            //chart1.Series["akdeniz"].Points.AddXY("adana", 24);
            //chart1.Series["akdeniz"].Points.AddXY("ısparta", 21);



            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select kategoriad,count(*) from tblkategori inner join tblurunler on tblkategori.kategoriid=tblurunler.kategori group by kategoriad ", baglanti);
            SqlDataReader dr=komut2.ExecuteReader();
            while(dr.Read())
            {
                chart1.Series["kategoriler"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();




            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select musterisehir,count(*) from tblmusteri group by musterisehir ", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                chart2.Series["Şehirler"].Points.AddXY(dr3[0], dr3[1]);
            }
            baglanti.Close();



        }
    }
}
