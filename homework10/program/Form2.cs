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

namespace program
{
    public partial class Form2 : Form
    {
        OrderService orderService = new OrderService();
        bool addMode = false;
        public Order CurrentOrder { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Order order) : this()
        {
            if (order == null)
            {
                addMode = true;
                CurrentOrder = new Order();
            }
            else
            {
                CurrentOrder = order;
            }
            orderBindingSource.DataSource = CurrentOrder;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (addMode)
            {
                orderService.Add(CurrentOrder);
            }
            else
            {
                orderService.Update(CurrentOrder);
            }
            this.Close();
        }
    }
}
