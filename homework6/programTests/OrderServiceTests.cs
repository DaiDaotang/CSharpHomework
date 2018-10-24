using Microsoft.VisualStudio.TestTools.UnitTesting;
using program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace program.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            try
            {
                Order order1 = new Order(1, "customer1");
                OrderService os = new OrderService();
                os.AddOrder(order1);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void DeleteByIdTest()
        {
            try
            {
                Order order1 = new Order(1, "customer1");
                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.DeleteById(1);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void DeleteByClientTest()
        {
            try
            {
                Order order1 = new Order(1, "customer1");
                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.DeleteByClient("customer1");
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CheckByNameTest()
        {
            Order order1 = new Order(1, "customer1");
            OrderDetail orderDetails1 = new OrderDetail(1, "apple", 3, 2);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> list = os.CheckByName("apple");
            Assert.AreEqual(list.Count, 1);
        }

        [TestMethod()]
        public void CheckByClientTest()
        {
            Order order1 = new Order(1, "customer1");
            OrderDetail orderDetails1 = new OrderDetail(1, "apple", 3, 2);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> list = os.CheckByClient("customer1");
            Assert.AreEqual(list.Count, 1);
        }

        [TestMethod()]
        public void CheckByIdTest()
        {
            Order order1 = new Order(1, "customer1");
            OrderDetail orderDetails1 = new OrderDetail(1, "apple", 3, 2);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> list = os.CheckById(1);
            Assert.AreEqual(list.Count, 1);
        }

        [TestMethod()]
        public void CheckOverTenThousandTest()
        {
            Order order1 = new Order(1, "customer1");
            OrderDetail orderDetails1 = new OrderDetail(1, "apple", 3, 2);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> list = os.CheckOverTenThousand();
            Assert.AreEqual(list.Count, 0);
        }

        [TestMethod()]
        public void ExportTest()
        {
            Order order1 = new Order(1, "customer1");
            OrderDetail orderDetails1 = new OrderDetail(1, "apple", 3, 2);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            FileInfo file = os.Export("testForExport.xml");
            Assert.IsTrue(file.Exists);
            file.Delete();
        }

        [TestMethod()]
        public void ImportTest()
        {
            Order order1 = new Order(1, "customer1");
            OrderDetail orderDetails1 = new OrderDetail(1, "apple", 3, 2);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            FileInfo file = os.Export("testForImport.xml");
            OrderService order = OrderService.Import("testForImport.xml");
            List<Order> list = order.CheckByClient("customer1");
            Assert.AreEqual(list.Count, 1);
            file.Delete();
        }
    }
}