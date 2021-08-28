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
using System.Data.OleDb;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //844; 316 normal
            // 844; 554 aşşağı açılma
            // 1067; 316 arama kısmı



            listele();
            textBox11.Enabled = false;
        }



        SqlConnection baglanti = new SqlConnection("Data Source=. ; Initial Catalog=veritabanı ; Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        DataTable tablo = new DataTable();
        public void listele()
        {
            tablo.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select * from kisiler", baglanti);
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }



        private void button7_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
          
            if (this.Height == 554)
            {
                this.Size = new Size(844, 316);
            }
            else
            { 
            this.Size=new Size(844,554);
            }
            

        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (this.Width == 1060)
            {
                this.Size = new Size(844,this.Height);
            }
            else
            {
                this.Size = new Size(1060,this.Height);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult basilan_tus2;
            basilan_tus2 = MessageBox.Show("Çıkmak İsteğinize Emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (basilan_tus2 == DialogResult.Yes)
            {
                Environment.Exit(-1);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         try
         {
                if ( textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
                {
                    MessageBox.Show("BOŞ BIRAKILAMAZ!");
                }
                else
                {
                    if (textBox5.Text.Contains("@"))
                    {
                        baglanti.Open();


                        
                        SqlCommand komut = new SqlCommand("insert into kisiler  values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);

                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        listele();
                    }
                    else
                    {
                        MessageBox.Show("Email'i Doğru Giriniz.");
                    }
                   
                }
          }
            catch
            {
                MessageBox.Show("Hatalı giriş / id,numara alanlarına dikkat ediniz");
            }
           
        }

      

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch { MessageBox.Show("Değer Yok!"); }
     
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                textBox11.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox12.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox13.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox14.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox15.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            catch
            {
               MessageBox.Show("Değer Yok!"); 
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox1.Enabled = true;
            if (this.Height == 554)
            {
                this.Size = new Size(844, 316);
            }
            else
            {
                this.Size = new Size(844, 554);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
            groupBox1.Enabled = false;
            if (this.Height == 554)
            {
                this.Size = new Size(this.Width, 316);
            }
            else
            {
                this.Size = new Size(this.Width, 554);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
            groupBox1.Enabled = false;
            if (this.Height == 554)
            {
                this.Size = new Size(this.Width, 316);
            }
            else
            {
                this.Size = new Size(this.Width, 554);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            
               try
                {
                    if (textBox6.Text == "")
                    {
                        baglanti.Open();
                        int x = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        SqlCommand komut = new SqlCommand("delete from kisiler where id= ('" + x + "')", baglanti);

                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        listele();
                    }
                    else
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("delete from kisiler where id= ('" + textBox6.Text + "')", baglanti);
                        textBox6.Text = "";
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        listele();
                    }
                }
                catch
                {

                    MessageBox.Show("Hatalı Seçim. ID giriniz veya tablo üzerinden seçiniz.");
                   
                    
                }
            
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox11.Text == "" && textBox12.Text == "" && textBox13.Text == "" && textBox14.Text == "" && textBox15.Text == "")
                {
                    MessageBox.Show("Boş Bırakılamaz.");
                }
                else
                {
                    if (textBox15.Text.Contains("@"))
                    {
                        baglanti.Open();

                        SqlCommand komut = new SqlCommand("update kisiler set adi='" + textBox12.Text + "', soyadi='" + textBox13.Text + "',cep_no='" + textBox14.Text + "',email='" + textBox15.Text + "' where id='" + textBox11.Text + "'", baglanti);

                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        listele();
                    }
                    else
                    {
                        MessageBox.Show("Email hatalı.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Verileri doğru gir");
            }
        }

  

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from kisiler where id like ('%" + textBox7.Text + "%')", baglanti);
            DataSet ds = new DataSet();
            adap.Fill(ds, "kisiler");
            this.dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        
        
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from kisiler where adi like ('%" + textBox8.Text + "%')", baglanti);
            DataSet ds = new DataSet();
            adap.Fill(ds, "kisiler");
            this.dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from kisiler where soyadi like ('%" + textBox9.Text + "%')", baglanti);
            DataSet ds = new DataSet();
            adap.Fill(ds, "kisiler");
            this.dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from kisiler where cep_no like ('%" + textBox10.Text + "%')", baglanti);
            DataSet ds = new DataSet();
            adap.Fill(ds, "kisiler");
            this.dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from kisiler where email like ('%" + textBox11.Text + "%')", baglanti);
            DataSet ds = new DataSet();
            adap.Fill(ds, "kisiler");
            this.dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

      
        private void button12_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                int x = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                SqlCommand komut = new SqlCommand("delete from kisiler ", baglanti);

                komut.ExecuteNonQuery();
                baglanti.Close();
                listele();
                
            }
            catch
            {
                MessageBox.Show("Veri yok");
            }
        }

      

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox6.Text == "")
                {
                    baglanti.Open();
                    int x = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    SqlCommand komut = new SqlCommand("delete from kisiler where id= ('" + x + "')", baglanti);

                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    listele();
                }
                else
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("delete from kisiler where id= ('" + textBox6.Text + "')", baglanti);
                    textBox6.Text = "";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    listele();
                }
            }
            catch
            {

                MessageBox.Show("Hatalı Seçim. ID giriniz veya tablo üzerinden seçiniz.");


            }
        }

    
    }
}
