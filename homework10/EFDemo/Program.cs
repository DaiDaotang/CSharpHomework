﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    class Program {
    static void Main(string[] args) {
      OrderService orderService = new OrderService();
      //orderService.Delete("001");

      List<OrderDetail> items = new List<OrderDetail>() {
                new OrderDetail("1", "apple", 10.0, 20),
                new OrderDetail("2", "egg", 2.0, 100)
            };

      Order order = new Order("001", "jia", items);

      orderService.Add(order);

      Order order2 = new Order("001", "jia2", items);
      orderService.Update(order2);


      List<Order> orders = orderService.QueryByCustormer("jia2");
      orders.ForEach(
        o => Console.WriteLine($"{o.Id},{o.Customer}"));


     }
    }
}
