using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using program;
using System.Text.RegularExpressions;

namespace program1
{
    public partial class Form1 : Form
    {
        //OrderService service = new OrderService();

        OrderService service = OrderService.Import ("s.xml");


        public Form1()
        {
            InitializeComponent();
            //OrderDetail orderDetails1 = new OrderDetail("1", "apple", 3, 2);
            //Order order1 = new Order("1", "customer1");
            //order1.AddDetails(orderDetails1);
            //OrderDetail orderDetails2 = new OrderDetail("2", "orange", 2, 1);
            //Order order2 = new Order("2", "customer2");
            //order2.AddDetails(orderDetails2);
            //service.AddOrder(order1);
            //service.AddOrder(order2);

            orderbinding.DataSource = service.OrderList;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void check_Click(object sender, EventArgs e)
        {
            if(comboBox1 .SelectedItem .ToString ()=="产品Id")
            {
                orderbinding.DataSource = service.CheckById(textBox1.Text);
            }
            else if(comboBox1.SelectedItem.ToString() == "用户名字")
            {
                orderbinding.DataSource = service.CheckByClient(textBox1.Text);
            }
            else if(comboBox1.SelectedItem.ToString() == "产品名字")
            {
                orderbinding.DataSource = service.CheckByProduct(textBox1.Text);
            }
        }
        private bool Save()
        {
            string phoneNum = @"^\+[0-9]{2}-[0-9]{2}-[0-9]{8}$";

            Regex rx1 = new Regex(phoneNum);

            foreach (var o in service.OrderList)
            {
                Match m1 = rx1.Match(o.PhoneNum);
                if (m1.Success == false)
                {
                    MessageBox.Show("电话号码格式错误");
                    return false;
                }
      
            }
            service.Export("s.xml"); 
            return true;
        }
        private void change_Click(object sender, EventArgs e)
        {

            Save();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "产品Id")
            {
                service.DeleteById(textBox1.Text);
                orderbinding.DataSource = service.OrderList;
            }
            else if (comboBox1.SelectedItem.ToString() == "用户名字")
            {
                service.DeleteByClient(textBox1.Text);
            }
            service.Export("s.xml");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            service.ExportHtml("s.html");
        }
    }
}
