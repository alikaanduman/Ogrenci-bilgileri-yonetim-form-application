using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public OleDbDataReader dtr;
        public OleDbConnection con;
        public OleDbDataAdapter data;
        public BindingSource bs;
        public OleDbCommandBuilder c;
        public DataTable dt;
        public OleDbCommand com;
        public string yol,sorgu;

        private void Form1_Load(object sender, EventArgs e)
        {
            baglan();
            combodoldur();
       textdoldur();
         doldur("select*from uye");
           
        }

        private void baglan()
        {
        yol="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|uyeler.accdb";
            con=new OleDbConnection(yol);
            con.Open();
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sorgu = "insert into uye(tcno,ads,dyer,dt,kilo,md,hobi) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox3.Text + "','" + radioButton1.Text + "','" + checkBox1.Text + "')";
            com = new OleDbCommand(sorgu, con);
            com.ExecuteNonQuery();
            doldur("select*from uye");
           
        }

        private void doldur(string sorgu1)
        {
            data = new OleDbDataAdapter(sorgu1, con);
            dt = new DataTable();
            data.Fill(dt);
            bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = dt;
        }
        
        
        private void textdoldur()
        {
          doldur("select*from uye");
          textBox1.DataBindings.Add("text", bs, "tcno");
          textBox2.DataBindings.Add("text", bs, "ads");
          textBox3.DataBindings.Add("text", bs, "kilo");
          comboBox1.DataBindings.Add("text", bs, "dyer");
          dateTimePicker1.DataBindings.Add("text", bs, "dt");
      

        }

        private void combodoldur()
        {
            data = new OleDbDataAdapter("Select*from sehirler", con);
            dt = new DataTable();
            data.Fill(dt);
            bs = new BindingSource();
            bs.DataSource = dt;
            foreach (DataRow ss in dt.Rows)
            {
                comboBox1.Items.Add(ss["sehir"].ToString());
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.MoveNext();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }
       

    }
}
