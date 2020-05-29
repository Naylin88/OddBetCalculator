using System;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace betStat
{
    public partial class clientEntry : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\App\betStat\betCal.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
     
        public clientEntry()
        {
            InitializeComponent();
            fComplete();
            upDown();
        }

        //clear data
        private void clear() {

            textBox1.Text = "";
        }

         //Fixture autofill
        private void fComplete() {

            foreach (var line in File.ReadAllLines(@"C:\App\betStat\fixture.txt"))
            {
                comboBox1.Items.Add(line);
            }

        }

        //Team of Choice
        private void upDown()
        {

            foreach (var line in File.ReadAllLines(@"C:\App\betStat\team.txt"))
            {
                comboBox2.Items.Add(line);
            }

        }

        //Fixtures and Odds
        private void button2_Click(object sender, EventArgs e)
        {
          
                cmd = new SqlCommand("INSERT INTO dbo.[fixtureOddResult](date,fixture,upDown,singleOddA,singleOddB,goalOddA,goalOddB) values(@a,@b,@ch,@c,@d,@e,@f)", con);

                con.Open();
              
                cmd.Parameters.AddWithValue("@a", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@b", comboBox1.Text);
                cmd.Parameters.AddWithValue("@ch", comboBox2.Text);
                cmd.Parameters.AddWithValue("@c", textBox2.Text);
                cmd.Parameters.AddWithValue("@d", textBox3.Text);
                cmd.Parameters.AddWithValue("@e", textBox7.Text);
                cmd.Parameters.AddWithValue("@f", textBox6.Text);
               // cmd.Parameters.AddWithValue("@g", textBox5.Text);
               // cmd.Parameters.AddWithValue("@h", textBox4.Text);

                cmd.ExecuteNonQuery();
          
            con.Close();
            MessageBox.Show("Record Inserted Successfully");
        }
 
        //Record
        private void button3_Click(object sender, EventArgs e)
        {
            Record frm2 = new Record();
            frm2.Show();
            this.Hide();
        }
    
        //Add client 
        private void button1_Click(object sender, EventArgs e)
        {

            using (StreamWriter objWriter = new StreamWriter(@"C:\App\betStat\CName.txt", true))
            {
                objWriter.WriteLine(textBox1.Text);
                objWriter.Close();
                
                //Message Box
                MessageBox.Show("Client Name has been saved");
                //Clear Text Box
                clear();
            }
        }

        private void formClose(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //REsult
        private void button4_Click(object sender, EventArgs e)
        {
            result frm2 = new result();
            frm2.Show();
            this.Hide();
        }
    }
}
