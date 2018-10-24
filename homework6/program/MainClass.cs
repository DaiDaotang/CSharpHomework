using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program
{
    class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
                OrderDetail orderDetails1 = new OrderDetail(1, "apple", 3, 2);
                OrderDetail orderDetails2 = new OrderDetail(2, "eggs", 2, 1);
                OrderDetail orderDetails3 = new OrderDetail(3, "milk", 1, 3);

                Order order1 = new Order(1, "customer1");
                Order order2 = new Order(2, "customer2");
                Order order3 = new Order(3, "customer3");

                order1.AddDetails(orderDetails1);
                order1.AddDetails(orderDetails2);
                order1.AddDetails(orderDetails3);
                order2.AddDetails(orderDetails2);
                order2.AddDetails(orderDetails3);
                order3.AddDetails(orderDetails3);

                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);

                Console.WriteLine("GetAllOrders");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByClient:'Customer2'");
                orders = os.CheckByClient("customer2");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByName:'apple'");
                orders = os.CheckByName("apple");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByPrice:10000");
                orders = os.CheckOverTenThousand();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("Remove order(id=2) and qurey all");
                os.DeleteById(2);
                os.QueryAllOrders().ForEach(
                    od => Console.WriteLine(od));

                os.Export();
                OrderService newService = OrderService.Import("s.xml");

                Console.WriteLine("GetAllOrders");
                List<Order> order = newService.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByClient:'Customer2'");
                order = newService.CheckByClient("customer2");
                foreach (Order od in order)
                    Console.WriteLine(od.ToString());

                Console.ReadLine();
            }
            catch (CanNotFindOrder e)
            {
                Console.WriteLine(e.Message);
                //Console.ReadLine();
            }
        }
    }
}
