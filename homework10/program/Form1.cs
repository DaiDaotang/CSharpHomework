using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orders;
using System.Text.RegularExpressions;

namespace program
{
    public partial class Form1 : Form
    {
        OrderService orderService = new OrderService();
        public Form1()
        {
            InitializeComponent();
            orderBindingSource.DataSource = orderService.GetAllOrders();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            queryOrder();
        }
        private void queryOrder()
        {
            switch (comboBox1.SelectedIndex)
            {

                case 1:
                    orderBindingSource.DataSource =
                      orderService.GetOrder(textBox1.Text);
                    break;
                case 2:
                    orderBindingSource.DataSource =
                      orderService.QueryByCustormer(textBox1.Text);
                    break;
                case 3:
                    orderBindingSource.DataSource =
                      orderService.QueryByGoods(textBox1.Text);
                    break;
                default:
                    orderBindingSource.DataSource = orderService.GetAllOrders();
                    break;
            }
            orderBindingSource.ResetBindings(false);
            orderDetailBindingSource.ResetBindings(false);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(null);
            form.ShowDialog();
            queryOrder();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2((Order)orderBindingSource.Current);
            form.ShowDialog();
            queryOrder();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Order order = (Order)orderBindingSource.Current;
            orderService.Delete(order.Id);
            queryOrder();
        }
    }
}
