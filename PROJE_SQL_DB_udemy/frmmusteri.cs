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
    public partial class frmmusteri : Form
    {
        public frmmusteri()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=ENES;Initial Catalog=satisVT;Integrated Security=True;");
      
        
        void listele()
        {
          SqlCommand komut= new SqlCommand("select * from tblmusteri ",baglanti);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
           dataGridView1.DataSource = dt;
        }


        private void frmmusteri_Load(object sender, EventArgs e)
        {
            listele();
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from tblsehirler ", baglanti);
            SqlDataReader dr= komut1.ExecuteReader();
            while (dr.Read())
            {
                combosehir.Items.Add(dr["sehirad"]);
            }
            baglanti.Close();

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            combosehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblmusteri (musteriid,musteriad,musterisoyad,musterisehir,musteribakiye) values(@p0,@p1,@p2,@p3,@p4 )", baglanti  );
            komut.Parameters.AddWithValue("@p0", txtid.Text);

            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", combosehir.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtbakiye.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Sisteme kaydedildi.");
            listele();

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from tblmusteri where musteriid=@p1 ", baglanti);
          komut.Parameters.AddWithValue("@p1",txtid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri silindi");
            listele();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update tblmusteri set musteriad=@p1 ,musterisoyad=@p2,musterisehir=@p3,musteribakiye=@p4 where musteriid=@p5 ", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", combosehir.Text);
            komut.Parameters.AddWithValue("@p4",decimal.Parse(txtbakiye.Text));
            komut.Parameters.AddWithValue("@p5", txtid.Text);


            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri güncellendi ");
            listele();

        }

        private void btnara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from tblmusteri where musteriad=@p1 ", baglanti);
            komut1.Parameters.AddWithValue("@p1",txtad.Text);
            SqlDataAdapter da=new SqlDataAdapter(komut1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
