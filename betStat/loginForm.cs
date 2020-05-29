using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace betStat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ppl" && textBox2.Text == "1234")
            {

                clientEntry frm = new clientEntry();
                frm.Show();
                this.Hide();

            }
            else {

                MessageBox.Show("Login Password Wrong!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fClose(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
