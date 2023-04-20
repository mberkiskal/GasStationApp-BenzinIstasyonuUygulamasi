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

namespace p18PetrolSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-23T2RIK\\SQLEXPRESS;Initial Catalog=p18BenzinSistemi;Integrated Security=True");

        void listele()
        {
            //Kurşunsuz95
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("select* from Table_Benzin where PETROLTURU='Kurşunsuz95'", conn);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                txtKursunsuz95.Text = dr[3].ToString();
                txtKursunsuz95A.Text = dr[2].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString());
                lblKursunsuz95litre.Text = dr[4].ToString();
            }
            conn.Close();

            //Kurşunsuz97
            conn.Open();
            SqlCommand sqlCommand2 = new SqlCommand("select* from Table_Benzin where PETROLTURU='Kurşunsuz97'", conn);
            SqlDataReader dr2 = sqlCommand2.ExecuteReader();
            while (dr2.Read())
            {
                txtKursunsuz97.Text = dr2[3].ToString();
                txtKursunsuz97A.Text = dr2[2].ToString();
                progressBar2.Value = int.Parse(dr2[4].ToString());
                lblKursunsuz97litre.Text = dr2[4].ToString();
            }
            conn.Close();

            //MaxDizel
            conn.Open();
            SqlCommand sqlCommand3 = new SqlCommand("select* from Table_Benzin where PETROLTURU='MaxDizel'", conn);
            SqlDataReader dr3 = sqlCommand3.ExecuteReader();
            while (dr3.Read())
            {
                txtMaxDizel.Text = dr3[3].ToString();
                txtMaxDizelA.Text = dr3[2].ToString();
                progressBar3.Value = int.Parse(dr3[4].ToString());
                lblMaxDizelLitre.Text = dr3[4].ToString();
            }
            conn.Close();

            //ProDizel
            conn.Open();
            SqlCommand sqlCommand4 = new SqlCommand("select* from Table_Benzin where PETROLTURU='ProDizel'", conn);
            SqlDataReader dr4 = sqlCommand4.ExecuteReader();
            while (dr4.Read())
            {
                txtProDizel.Text = dr4[3].ToString();
                txtProDizelA.Text = dr4[2].ToString();
                progressBar4.Value = int.Parse(dr4[4].ToString());
                lblProDizelLitre.Text = dr4[4].ToString();
            }
            conn.Close();

            //Gaz
            conn.Open();
            SqlCommand sqlCommand5 = new SqlCommand("select* from Table_Benzin where PETROLTURU='Gaz'", conn);
            SqlDataReader dr5 = sqlCommand5.ExecuteReader();
            while (dr5.Read())
            {
                txtGaz.Text = dr5[3].ToString();
                txtGazA.Text = dr5[2].ToString();
                progressBar5.Value = int.Parse(dr5[4].ToString());
                lblGazLitre.Text = dr5[4].ToString();
            }
            conn.Close();


            conn.Open();
            SqlCommand cmd6 = new SqlCommand("select * from Table_Kasa", conn);
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            {
                lblKasa.Text = dr6[0].ToString();
            }
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar, gider;
            kursunsuz95=Convert.ToDouble(txtKursunsuz95.Text);
            gider = Convert.ToDouble(txtKursunsuz95A.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * litre;
            txtKursunsuz95Fiyat.Text=tutar.ToString();
            tutar = gider * litre;
            txtK95AL.Text = tutar.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, litre, tutar, gider;
            kursunsuz97 = Convert.ToDouble(txtKursunsuz97.Text);
            gider = Convert.ToDouble(txtKursunsuz97A.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = kursunsuz97 * litre;
            txtKursunsuz97Fiyat.Text = tutar.ToString();
            tutar = gider * litre;
            txtK97AL.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double maxdizel, litre, tutar, gider;
            maxdizel = Convert.ToDouble(txtMaxDizel.Text);
            gider = Convert.ToDouble(txtMaxDizelA.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = maxdizel * litre;
            txtMaxDizelFiyat.Text = tutar.ToString();
            tutar = gider * litre;
            txtMaxDizelAL.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double prodizel, litre, tutar, gider;
            prodizel = Convert.ToDouble(txtProDizel.Text);
            gider = Convert.ToDouble(txtProDizelA.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = prodizel * litre;
            txtProDizelFiyat.Text = tutar.ToString();
            tutar = gider * litre;
            txtProDizelAL.Text = tutar.ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar,gider;
            gaz = Convert.ToDouble(txtGaz.Text);
            gider = Convert.ToDouble(txtGazA.Text);
            litre = Convert.ToDouble(numericUpDown5.Value);
            tutar = gaz * litre;
            txtGazFiyat.Text = tutar.ToString();
            tutar = gider * litre;
            txtGazAL.Text = tutar.ToString();
        }

        private void btnDepoDoldur_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Table_Hareket (PLAKA,BENZINTURU,LITRE,ODEME) values (@p1,@p2,@p3,@p4)",conn);
                cmd.Parameters.AddWithValue("@p1",txtPlaka.Text);
                cmd.Parameters.AddWithValue("@p2", "Kurşunsuz95");
                cmd.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtKursunsuz95.Text));
                cmd.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand cmd2 = new SqlCommand("update Table_Kasa set KASAMIKTAR=KASAMIKTAR+@p1", conn);
                cmd2.Parameters.AddWithValue("@p1", decimal.Parse(txtKursunsuz95Fiyat.Text));
                cmd2.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd4 = new SqlCommand("update Table_Kasa set KASAMIKTAR=KASAMIKTAR-@p1", conn);
                cmd4.Parameters.AddWithValue("@p1", decimal.Parse(txtK95AL.Text));
                cmd4.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand cmd3 = new SqlCommand("update Table_Benzin set STOK=STOK-@p1 where PETROLTURU='Kurşunsuz95'", conn);
                cmd3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Satış Yapıldı!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            if (numericUpDown2.Value != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Table_Hareket (PLAKA,BENZINTURU,LITRE,ODEME) values (@p1,@p2,@p3,@p4)", conn);
                cmd.Parameters.AddWithValue("@p1", txtPlaka.Text);
                cmd.Parameters.AddWithValue("@p2", "Kurşunsuz97");
                cmd.Parameters.AddWithValue("@p3", numericUpDown2.Value);
                cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtKursunsuz97.Text));
                cmd.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand cmd2 = new SqlCommand("update Table_Kasa set KASAMIKTAR=KASAMIKTAR+@p1", conn);
                cmd2.Parameters.AddWithValue("@p1", decimal.Parse(txtKursunsuz97Fiyat.Text));
                cmd2.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd4 = new SqlCommand("update Table_Kasa set KASAMIKTAR=KASAMIKTAR-@p1", conn);
                cmd4.Parameters.AddWithValue("@p1", decimal.Parse(txtK97AL.Text));
                cmd4.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand cmd3 = new SqlCommand("update Table_Benzin set STOK=STOK-@p1 where PETROLTURU='Kurşunsuz97'", conn);
                cmd3.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Satış Yapıldı!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            if (numericUpDown3.Value != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Table_Hareket (PLAKA,BENZINTURU,LITRE,ODEME) values (@p1,@p2,@p3,@p4)", conn);
                cmd.Parameters.AddWithValue("@p1", txtPlaka.Text);
                cmd.Parameters.AddWithValue("@p2", "MaxDizel");
                cmd.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtMaxDizel.Text));
                cmd.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand cmd2 = new SqlCommand("update Table_Kasa set KASAMIKTAR=KASAMIKTAR+@p1", conn);
                cmd2.Parameters.AddWithValue("@p1", decimal.Parse(txtMaxDizelFiyat.Text));
                cmd2.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd4 = new SqlCommand("update Table_Kasa set KASAMIKTAR=KASAMIKTAR-@p1", conn);
                cmd4.Parameters.AddWithValue("@p1", decimal.Parse(txtMaxDizelAL.Text));
                cmd4.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand cmd3 = new SqlCommand("update Table_Benzin set STOK=STOK-@p1 where PETROLTURU='MaxDizel'", conn);
                cmd3.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Satış Yapıldı!","İşlem Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                listele();
            }
            if (numericUpDown4.Value != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Table_Hareket (PLAKA,BENZINTURU,LITRE,ODEME) values (@p1,@p2,@p3,@p4)", conn);
                cmd.Parameters.AddWithValue("@p1", txtPlaka.Text);
                cmd.Parameters.AddWithValue("@p2", "MaxDizel");
                cmd.Parameters.AddWithValue("@p3", numericUpDown4.Value);
                cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtProDizel.Text));
                cmd.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand cmd2 = new SqlCommand("update Table_Kasa set KASAMIKTAR=KASAMIKTAR+@p1", conn);
                cmd2.Parameters.AddWithValue("@p1", decimal.Parse(txtProDizelFiyat.Text));
                cmd2.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd4 = new SqlCommand("update Table_Kasa set KASAMIKTAR=KASAMIKTAR-@p1", conn);
                cmd4.Parameters.AddWithValue("@p1", decimal.Parse(txtProDizelAL.Text));
                cmd4.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand cmd3 = new SqlCommand("update Table_Benzin set STOK=STOK-@p1 where PETROLTURU='ProDizel'", conn);
                cmd3.Parameters.AddWithValue("@p1", numericUpDown4.Value);
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Satış Yapıldı!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            if (numericUpDown5.Value != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Table_Hareket (PLAKA,BENZINTURU,LITRE,ODEME) values (@p1,@p2,@p3,@p4)", conn);
                cmd.Parameters.AddWithValue("@p1", txtPlaka.Text);
                cmd.Parameters.AddWithValue("@p2", "Gaz");
                cmd.Parameters.AddWithValue("@p3", numericUpDown5.Value);
                cmd.Parameters.AddWithValue("@p4", decimal.Parse(txtGaz.Text));
                cmd.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand cmd2 = new SqlCommand("update Table_Kasa set KASAMIKTAR=KASAMIKTAR+@p1", conn);
                cmd2.Parameters.AddWithValue("@p1", decimal.Parse(txtGazFiyat.Text));
                cmd2.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd4 = new SqlCommand("update Table_Kasa set KASAMIKTAR=KASAMIKTAR-@p1", conn);
                cmd4.Parameters.AddWithValue("@p1", decimal.Parse(txtGazAL.Text));
                cmd4.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand cmd3 = new SqlCommand("update Table_Benzin set STOK=STOK-@p1 where PETROLTURU='Gaz'", conn);
                cmd3.Parameters.AddWithValue("@p1", numericUpDown5.Value);
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Satış Yapıldı!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Bu İşlemi Onaylıyor Musunuz?", "BU İŞLEM ONAY GEREKTİRİR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if (cmbSecim.SelectedIndex == 0)
                {
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("update Table_Benzin set STOK='10000' where PETROLTURU='Kurşunsuz95'", conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }
                if (cmbSecim.SelectedIndex == 1)
                {
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("update Table_Benzin set STOK='10000' where PETROLTURU='Kurşunsuz97'", conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }
                if (cmbSecim.SelectedIndex == 2)
                {
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("update Table_Benzin set STOK='10000' where PETROLTURU='MaxDizel'", conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }
                if (cmbSecim.SelectedIndex == 3)
                {
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("update Table_Benzin set STOK='10000' where PETROLTURU='ProDizel'", conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }
                if (cmbSecim.SelectedIndex == 4)
                {
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("update Table_Benzin set STOK='10000' where PETROLTURU='Gaz'", conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }
                listele();
            }
            else
            {
                MessageBox.Show("İşlem Reddedildi!","BU İŞLEM ONAY GEREKTİRİR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
    }
}
