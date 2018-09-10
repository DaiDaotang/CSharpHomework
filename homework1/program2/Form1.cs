using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string s = " ";
        string t = " ";
        double a, b;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s = textBox1.Text;
            a = Double.Parse(s);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = "乘积是" + a * b; 
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            t = textBox2.Text;
            b = Double.Parse(t);
        }
    }
}
