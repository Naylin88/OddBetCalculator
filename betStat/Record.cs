using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.ComponentModel;

namespace betStat
{
    public partial class Record : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\App\betStat\betCal.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapt;
        int ID = 0;

        public Record()
        {
            InitializeComponent();
            display();
            display2();
            dataFill();
        }

        private void Record_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'betCalDataSet.singleBet' table. You can move, or remove it, as needed.
            this.singleBetTableAdapter.Fill(this.betCalDataSet.singleBet);

        }

        //Clear
        private void clear() {
            textBox6.Text = "";
            textBox1.Text = "1";
            label9.Text = "$";
            textBox7.Text = "";
            textBox8.Text = "1";
            label18.Text = "$";
        }
        //Data fill in combobox
        private void dataFill()
        {

            foreach (var line in File.ReadAllLines(@"C:\App\betStat\CName.txt"))
            {
                comboBox1.Items.Add(line);
                comboBox4.Items.Add(line);
                comboBox6.Items.Add(line);
                comboBox7.Items.Add(line);
                comboBox10.Items.Add(line);
            }
        }
        //Link Button
        private void button1_Click(object sender, EventArgs e)
        {
            clientEntry frm = new clientEntry();
            frm.Show();
            this.Dispose();
        }
        //DatePick and Data fill
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
        //Fixture Select and Data Fill in txt box
        private void fixtureSelect(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            cmd = new SqlCommand("Select singleOddA,singleOddB,resultA,resultB,upDown from dbo.[fixtureOddResult] where fixture ='" + comboBox2.Text + "'", con);

            reader = cmd.ExecuteReader();

            if (reader.Read())

            {

                textBox2.Text = reader["singleOddA"].ToString();
                textBox3.Text = reader["singleOddB"].ToString();
                textBox4.Text = reader["resultA"].ToString();
                textBox5.Text = reader["resultB"].ToString();
                label12.Text = reader["upDown"].ToString();
                reader.Close();
                con.Close();

            }
        }
        //display data
        private void display()
        {

            con.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select * from [singleBet]", con);
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            //DataGridView sorting in desc...
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
            con.Close();

        }
        //display data2
        private void display2()
        {
            con.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select * from [totalBet]", con);
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            dataGridView4.DataSource = dt;
            //DataGridView sorting in desc...
            dataGridView4.Sort(dataGridView4.Columns[0], ListSortDirection.Descending);
            con.Close();

        }
        //DataGrid select by mouse click
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                label9.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();

            }
            else
            {
                MessageBox.Show("Please Select Correct RowHeader!");
            }
        }
        //Save
        private void button2_Click(object sender, EventArgs e)
        {
            //insert into database
            cmd = new SqlCommand("INSERT INTO dbo.[singleBet](clientName,date,fixture,choice,singleOddA,singleOddB,resultA,resultB,commission,betAmount,winLoss) values( @a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k)", con);

            con.Open();
            cmd.Parameters.AddWithValue("@a", comboBox1.Text);
            cmd.Parameters.AddWithValue("@b", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@c", comboBox2.Text);
            cmd.Parameters.AddWithValue("@d", comboBox3.Text);
            cmd.Parameters.AddWithValue("@e", textBox2.Text);
            cmd.Parameters.AddWithValue("@f", textBox3.Text);
            cmd.Parameters.AddWithValue("@g", textBox4.Text);
            cmd.Parameters.AddWithValue("@h", textBox5.Text);
            cmd.Parameters.AddWithValue("@i", textBox1.Text);
            cmd.Parameters.AddWithValue("@j", textBox6.Text);
            cmd.Parameters.AddWithValue("@k", label9.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            display();
            MessageBox.Show("Record is added successfully!");
            clear();

        }
        //Calculating
        private void calc()
        {
            if (textBox1.Text != "" && textBox6.Text != "")
            {

                double winLoss;

                int x = Convert.ToInt32(textBox2.Text);
                int y = Convert.ToInt32(textBox3.Text);
                int r0 = Convert.ToInt32(textBox4.Text);
                int r1 = Convert.ToInt32(textBox5.Text);
                double com = Convert.ToDouble(textBox1.Text);
                double betAmount = Convert.ToDouble(textBox6.Text);
                int diff0 = (r0 - r1);
                int diff1 = (r1 - r0);


                if (comboBox3.Text == "UP" && checkBox1.Checked == true)//Home UP
                {
                    if (diff0 > x)
                    {
                        winLoss = betAmount * com;
                        label9.Text = winLoss.ToString();
                    }
                    else if (diff0 < x)
                    {
                        winLoss = -(betAmount * com);
                        label9.Text = winLoss.ToString();
                    }
                    else
                    {
                        winLoss = ((betAmount * y) / 100) * com;
                        label9.Text = winLoss.ToString();

                    }
                }

                else if (comboBox3.Text == "DOWN" && checkBox1.Checked == true)//Home Down
                {
                    if (diff0 < x)
                    {

                        winLoss = betAmount * com;
                        label9.Text = winLoss.ToString();
                    }
                    else if (diff0 > x)
                    {

                        winLoss = -(betAmount * com);
                        label9.Text = winLoss.ToString();
                    }
                    else
                    {

                        winLoss = -(((betAmount * y) / 100) * com);
                        label9.Text = winLoss.ToString();

                    }
                }
                else if (comboBox3.Text == "UP" && checkBox2.Checked == true)
                {
                    if (diff1 > x)
                    {
                        winLoss = betAmount * com;
                        label9.Text = winLoss.ToString();
                    }
                    else if (diff1 < x)
                    {

                        winLoss = -(betAmount * com);
                        label9.Text = winLoss.ToString();
                    }
                    else
                    {
                        winLoss = ((betAmount * y) / 100) * com;
                        label9.Text = winLoss.ToString();

                    }
                }
               
                else if (comboBox3.Text == "DOWN" && checkBox2.Checked == true)
                {
                    if (diff1 < x)//Change
                    {

                        winLoss = betAmount * com;
                        label9.Text = winLoss.ToString();
                    }
                    else if (diff1 > x)
                    {

                        winLoss = -(betAmount * com);
                        label9.Text = winLoss.ToString();
                    }
                    else
                    {

                        winLoss = -(((betAmount * y) / 100) * com);
                        label9.Text = winLoss.ToString();

                    }

                }
                else
                {

                    MessageBox.Show("Please check your data carefully or Click 'HOME OR AWAY'!");
                }

            }//Validation
            else {
                MessageBox.Show("Commission and Bet Amount can't be blank!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            calc();
        }
        //search
        private void button6_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from [singleBet] where clientName='" + comboBox6.Text + "' and date='" + dateTimePicker6.Value + "'", con);
            con.Open();
            adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();


            if (dt == null)
            {
                MessageBox.Show("Record is not found!");
            }
        }
        //Update
        private void button7_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update [singleBet] set clientName=@a,date=@b,fixture=@c,choice=@d,singleOddA=@e,singleOddB=@f,resultA=@g,resultB=@h,commission=@i,betAmount=@j,winLoss=@k where singleBetId=@id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@a", comboBox1.Text);
            cmd.Parameters.AddWithValue("@b", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@c", comboBox2.Text);
            cmd.Parameters.AddWithValue("@d", comboBox3.Text);
            cmd.Parameters.AddWithValue("@e", textBox2.Text);
            cmd.Parameters.AddWithValue("@f", textBox3.Text);
            cmd.Parameters.AddWithValue("@g", textBox4.Text);
            cmd.Parameters.AddWithValue("@h", textBox5.Text);
            cmd.Parameters.AddWithValue("@i", textBox1.Text);
            cmd.Parameters.AddWithValue("@j", textBox6.Text);
            cmd.Parameters.AddWithValue("@k", label9.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            display();
            MessageBox.Show("Record Updated Successfully");
            clear();
        }
        //Delete
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete [singleBet] where singleBetId=@a", con);
                con.Open();
                cmd.Parameters.AddWithValue("@a", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                display();
                clear();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
        //Stat SingleBet
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox11.Text == "Single Bet")
            {
                if (comboBox4.Text == "BOOKIE")
                {

                    cmd = new SqlCommand("SELECT clientName,date,fixture,choice,betAmount,winLoss FROM [singleBet] WHERE Date >=@d1 and Date <= @d2", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@d1", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@d2", dateTimePicker3.Value);
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                else
                {

                    cmd = new SqlCommand("SELECT clientName,date,fixture,choice,betAmount,winLoss FROM [singleBet] WHERE clientName=@cn and Date >=@d1 and Date <= @d2", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@cn", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@d1", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@d2", dateTimePicker3.Value);
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                //Calculate Total

                double total = 0;
                double temp = 0;
                double plus = 0;
                double minus = 0;

                foreach (DataGridViewRow r in dataGridView2.Rows)
                {

                    temp = Convert.ToDouble(r.Cells[5].Value);
                    total += temp;
                    if (temp > 0)
                    {
                        plus += temp;
                    }
                    else
                    {
                        minus += temp;
                    }
                }
                label13.Text = total.ToString();
                label14.Text = plus.ToString();
                label15.Text = minus.ToString();
            }//end of single Bet
            else if (comboBox11.Text == "Total Goal")
            {

                if (comboBox4.Text == "BOOKIE")
                {
                    cmd = new SqlCommand("SELECT clientName,date,fixture,choice,betAmount,winLoss FROM [totalBet] WHERE Date >=@d1 and Date <= @d2", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@d1", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@d2", dateTimePicker3.Value);
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                else
                {

                    cmd = new SqlCommand("SELECT clientName,date,fixture,choice,betAmount,winLoss FROM [totalBet] WHERE clientName=@cn and Date >=@d1 and Date <= @d2", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@cn", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@d1", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@d2", dateTimePicker3.Value);
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();

                }

                //Calculate Total

                double total = 0;
                double temp = 0;
                double plus = 0;
                double minus = 0;

                foreach (DataGridViewRow r in dataGridView2.Rows)
                {

                    temp = Convert.ToDouble(r.Cells[5].Value);
                    total += temp;
                    if (temp > 0)
                    {
                        plus += temp;
                    }
                    else
                    {
                        minus += temp;
                    }
                }
                label13.Text = total.ToString();
                label14.Text = plus.ToString();
                label15.Text = minus.ToString();

            }
            else if (comboBox11.Text == "Total WinLoss")
            {
                if (comboBox4.Text == "BOOKIE")
                {
                    cmd = new SqlCommand("SELECT clientName,date,fixture,choice,betAmount,winLoss FROM [singleBet] union SELECT clientName,date,fixture,choice,betAmount,winLoss FROM [totalBet] WHERE Date >=@d1 and Date <= @d2", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@d1", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@d2", dateTimePicker3.Value);
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                else
                {

                    cmd = new SqlCommand("SELECT clientName,date,fixture,choice,betAmount,winLoss FROM [singleBet] WHERE clientName=@cn and Date >=@d1 and Date <= @d2 union SELECT clientName,date,fixture,choice,betAmount,winLoss FROM [totalBet] WHERE clientName=@cn and Date >=@d1 and Date <= @d2", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@cn", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@d1", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@d2", dateTimePicker3.Value);
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();

                }

                //Calculate Total

                double total = 0;
                double temp = 0;
                double plus = 0;
                double minus = 0;

                foreach (DataGridViewRow r in dataGridView2.Rows)
                {

                    temp = Convert.ToDouble(r.Cells[5].Value);
                    total += temp;
                    if (temp > 0)
                    {
                        plus += temp;
                    }
                    else
                    {
                        minus += temp;
                    }
                }
                label13.Text = total.ToString();
                label14.Text = plus.ToString();
                label15.Text = minus.ToString();
            }
            else {
                MessageBox.Show("Select Correct type");
            }

        }

      
        /**
         * total Goals
         * **/

       
        //datePick
        private void datepick2(object sender, EventArgs e)
        {
            String date = dateTimePicker7.Value.ToString();

            con.Open();
            adapt = new SqlDataAdapter("Select fixture from dbo.[fixtureOddResult] where date ='" + date + "'", con);

            DataSet dt = new DataSet();
            adapt.Fill(dt);

            comboBox9.DataSource = dt.Tables[0]; /// assing the first table of dataset        
            comboBox9.DisplayMember = "fixture";

            con.Close();
        }
        //Fixture Select for Total Goal
        private void fixtureSelect2(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            cmd = new SqlCommand("Select goalOddA,goalOddB,resultA,resultB from dbo.[fixtureOddResult] where fixture ='" + comboBox9.Text + "'", con);

            reader = cmd.ExecuteReader();

            if (reader.Read())

            {
                textBox12.Text = reader["goalOddA"].ToString();
                textBox11.Text = reader["goalOddB"].ToString();
                textBox9.Text = reader["resultA"].ToString();
                textBox10.Text = reader["resultB"].ToString();
                
                reader.Close();
                con.Close();

            }
        }
        //Calc
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "" && textBox7.Text != "")
            {
                double winLoss;

                int x = Convert.ToInt32(textBox12.Text);
                int y = Convert.ToInt32(textBox11.Text);
                int r0 = Convert.ToInt32(textBox9.Text);
                int r1 = Convert.ToInt32(textBox10.Text);
                double com = Convert.ToDouble(textBox8.Text);
                double betAmount = Convert.ToDouble(textBox7.Text);
                int diff0 = (r0 + r1);

                if (comboBox8.Text == "OVER")
                {
                    if (diff0 > x)
                    {

                        winLoss = betAmount * com;
                        label18.Text = winLoss.ToString();
                    }
                    else if (diff0 < x)
                    {
                        winLoss = -betAmount * com;
                        label18.Text = winLoss.ToString();
                    }
                    else
                    {
                        winLoss = ((betAmount * y) / 100) * com;
                        label18.Text = winLoss.ToString();
                    }

                }
                else if (comboBox8.Text == "UNDER")
                {
                    if (diff0 < x)
                    {

                        winLoss = betAmount * com;
                        label18.Text = winLoss.ToString();
                    }
                    else if (diff0 > x)
                    {
                        winLoss = -betAmount * com;
                        label18.Text = winLoss.ToString();
                    }
                    else
                    {
                        winLoss = -((betAmount * y) / 100) * com;
                        label18.Text = winLoss.ToString();
                    }

                }
                else
                {
                    MessageBox.Show("Something went Wrong!");
                }

            }//VAlidation
            else
            {
                MessageBox.Show("Commission and Bet Amount can't be blank!");
            }
        }
        //Save
        private void button13_Click(object sender, EventArgs e)
        {
            //insert into database
            cmd = new SqlCommand("INSERT INTO dbo.[totalBet](clientName,date,fixture,choice,goalOddA,goalOddB,resultA,resultB,commission,betAmount,winLoss) values( @a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k)", con);

            con.Open();
            cmd.Parameters.AddWithValue("@a", comboBox10.Text);
            cmd.Parameters.AddWithValue("@b", dateTimePicker7.Value);
            cmd.Parameters.AddWithValue("@c", comboBox9.Text);
            cmd.Parameters.AddWithValue("@d", comboBox8.Text);
            cmd.Parameters.AddWithValue("@e", textBox12.Text);
            cmd.Parameters.AddWithValue("@f", textBox11.Text);
            cmd.Parameters.AddWithValue("@g", textBox9.Text);
            cmd.Parameters.AddWithValue("@h", textBox10.Text);
            cmd.Parameters.AddWithValue("@i", textBox8.Text);
            cmd.Parameters.AddWithValue("@j", textBox7.Text);
            cmd.Parameters.AddWithValue("@k", label18.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            display2();
            MessageBox.Show("Record is added successfully!");
            clear();
        }
        //Cellclick
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                ID = Convert.ToInt32(dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString());
                dateTimePicker7.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox10.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox9.Text = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox8.Text = dataGridView4.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox8.Text = dataGridView4.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox7.Text = dataGridView4.Rows[e.RowIndex].Cells[6].Value.ToString();
                label18.Text = dataGridView4.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox12.Text = dataGridView4.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBox11.Text = dataGridView4.Rows[e.RowIndex].Cells[9].Value.ToString();
                textBox9.Text = dataGridView4.Rows[e.RowIndex].Cells[10].Value.ToString();
                textBox10.Text = dataGridView4.Rows[e.RowIndex].Cells[11].Value.ToString();

            }
            else
            {
                MessageBox.Show("Please Select Correct RowHeader!");
            }
        }
        //Update
        private void button10_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update [totalBet] set clientName=@a,date=@b,fixture=@c,choice=@d,goalOddA=@e,goalOddB=@f,resultA=@g,resultB=@h,commission=@i,betAmount=@j,winLoss=@k where totalBetId=@id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@a", comboBox10.Text);
            cmd.Parameters.AddWithValue("@b", dateTimePicker7.Value);
            cmd.Parameters.AddWithValue("@c", comboBox9.Text);
            cmd.Parameters.AddWithValue("@d", comboBox8.Text);
            cmd.Parameters.AddWithValue("@e", textBox12.Text);
            cmd.Parameters.AddWithValue("@f", textBox11.Text);
            cmd.Parameters.AddWithValue("@g", textBox9.Text);
            cmd.Parameters.AddWithValue("@h", textBox10.Text);
            cmd.Parameters.AddWithValue("@i", textBox8.Text);
            cmd.Parameters.AddWithValue("@j", textBox7.Text);
            cmd.Parameters.AddWithValue("@k", label18.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            display2();
            MessageBox.Show("Record Updated Successfully");
            clear();
        }
        //Delete
        private void button12_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete [totalBet] where totalBetId=@a", con);
                con.Open();
                cmd.Parameters.AddWithValue("@a", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                display2();
                clear();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
        //Search
        private void button11_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from [totalBet] where clientName='" + comboBox7.Text + "' and date='" + dateTimePicker8.Value + "'", con);
            con.Open();
            adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView4.DataSource = dt;

            con.Close();


            if (dt == null)
            {
                MessageBox.Show("Record is not found!");
            }
        }

        private void FormClose(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //Cell Color Change
        private void dataGridView1_rowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           
            foreach (DataGridViewRow r in dataGridView1.Rows) {
                
                int rowColorChange = Convert.ToInt32(r.Cells[7].Value);
                if (rowColorChange < 0)
                {
                
                    r.Cells[7].Style.ForeColor = System.Drawing.Color.Red;
                   
                }
                else
                {
                    r.Cells[7].Style.ForeColor = System.Drawing.Color.Blue;
                  
                }
             
            }
          
        }
        //GridView4 Color
        private void GridView4_rowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView4.Rows)
            {

                int rowColorChange = Convert.ToInt32(r.Cells[7].Value);
                if (rowColorChange < 0)
                {
                    r.Cells[7].Style.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    r.Cells[7].Style.ForeColor = System.Drawing.Color.Blue;
                }
            }
        }
        //DGV2
        private void Gridview2_rowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView2.Rows)
            {
                //5
                int rowColorChange = Convert.ToInt32(r.Cells[5].Value);
                if (rowColorChange < 0)
                {
                    r.Cells[5].Style.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    r.Cells[5].Style.ForeColor = System.Drawing.Color.Blue;
                }
            }
        }
       
        
    }
}

