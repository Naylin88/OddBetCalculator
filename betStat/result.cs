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

namespace betStat
{
    public partial class result : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\App\betStat\betCal.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd, cmd2, cmd3;
        SqlDataReader reader;
        SqlDataAdapter adapt;
        int ID = 0;

        public result()
        {
            InitializeComponent();
            display();
        }

        //display data
        private void display()
        {

            con.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select * from [fixtureOddResult]", con);
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            //DataGridView sorting in desc...
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
            con.Close();

        }

        private void clear()
        {

            textBox4.Text = "";
            textBox5.Text = "";
        }
        //result Update
        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update [fixtureOddResult] set resultA=@a,resultB=@b where fixtureId=@id", con);
            cmd2 = new SqlCommand("update [singleBet] set resultA=@aa,resultB=@bb where date=@c and fixture=@d", con);
            cmd3 = new SqlCommand("update [totalBet] set resultA=@aa,resultB=@bb where date=@c and fixture=@d", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", ID);  
            cmd.Parameters.AddWithValue("@a", textBox5.Text);
            cmd.Parameters.AddWithValue("@b", textBox4.Text);
            cmd2.Parameters.AddWithValue("@aa", textBox5.Text);
            cmd2.Parameters.AddWithValue("@bb", textBox4.Text);
            cmd2.Parameters.AddWithValue("@c", dateTimePicker1.Value);
            cmd2.Parameters.AddWithValue("@d", comboBox2.Text);
            cmd3.Parameters.AddWithValue("@aa", textBox5.Text);
            cmd3.Parameters.AddWithValue("@bb", textBox4.Text);
            cmd3.Parameters.AddWithValue("@c", dateTimePicker1.Value);
            cmd3.Parameters.AddWithValue("@d", comboBox2.Text);

            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            con.Close();
            display();
            MessageBox.Show("Record Updated Successfully");
            clear();
        }
        //Datepick
        private void datePick(object sender, EventArgs e)
        {
            String date = dateTimePicker1.Value.ToString();

            con.Open();
            adapt = new SqlDataAdapter("Select fixture from dbo.[fixtureOddResult] where date ='" + date + "'", con);

            DataSet dt = new DataSet();
            adapt.Fill(dt);

            comboBox2.DataSource = dt.Tables[0]; /// assing the first table of dataset        
            comboBox2.DisplayMember = "fixture";

            con.Close();
        }

        private void selectChangeDataFill(object sender, EventArgs e)
        {
             con.Close();
             con.Open();

            cmd = new SqlCommand("Select resultA,resultB from dbo.[fixtureOddResult] where fixture ='" + comboBox2.Text + "'", con);

            reader = cmd.ExecuteReader();

            if (reader.Read())

            {
                textBox5.Text = reader["resultA"].ToString();
                textBox4.Text = reader["resultB"].ToString();

                reader.Close();
                con.Close();

            }
        }

        private void result_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'betCalDataSet.fixtureOddResult' table. You can move, or remove it, as needed.
            this.fixtureOddResultTableAdapter.Fill(this.betCalDataSet.fixtureOddResult);

        }
        //CellClick Data Fill
        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
            else
            {
                MessageBox.Show("Please Select Correct RowHeader!");
            }
        }
        //delete
        private void button1_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete [fixtureOddResult] where fixtureId=@a", con);
                con.Open();
                cmd.Parameters.AddWithValue("@a", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                display();
             
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
        //Form Closed
        private void formClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clientEntry frm = new clientEntry();
            frm.Show();
            this.Dispose();
        }
    }
}
