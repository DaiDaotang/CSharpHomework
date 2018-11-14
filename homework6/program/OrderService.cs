using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;


namespace program
{
    [Serializable]
    public class OrderService
    {
        private List<Order> orderList;
        public OrderService()
        {
            orderList = new List<Order>();
        }

        public List<Order> OrderList { get => orderList; set => orderList = value; }

        public void AddOrder(Order newOrder)
        {
            orderList.Add(newOrder);
        }
        public List<Order> QueryAllOrders()
        {
            return orderList.ToList();
        }
        public void DeleteById(string id)
        {
            bool find = false;
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].Id == id)
                {
                    orderList.Remove(orderList[i]);
                    find = true;
                }
            }
            if (!find)
            {
                throw new CanNotFindOrder($"没有ID为{id}的订单");
            }
        }
        //public void DeleteByName(string name)
        //{
        //    bool find = false;
        //    for (int i = 0; i < orderList.Count; i++)
        //    {
        //        if (orderList[i].Details.Name == name)
        //        {
        //            orderList.Remove(orderList[i]);
        //            find = true;
        //        }
        //    }
        //    if (!find)
        //    {
        //        throw new CanNotFindOrder($"没有名为{name}的订单");
        //    }
        //}
        public void DeleteByClient(String client)
        {
            bool find = false;
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].Client == client)
                {
                    orderList.Remove(orderList[i]);
                    find = true;
                }
            }
            if (!find)
            {
                throw new CanNotFindOrder($"没有客户为{client}的订单");
            }
        }
        public List<Order> CheckByProduct(string product)
        {
            var query = orderList
                .Where(order => order.Details.Where(d=>d.Product == product).Count()>0);
            return query.ToList();
            throw new CanNotFindOrder($"没有名为{product}的订单");
        }
        public List<Order> CheckByClient(string client)
        {
            var query = orderList
                .Where(order => order.Client == client);
            return query.ToList();
            throw new CanNotFindOrder($"没有客户为{client}的订单");
        }
        public List<Order> CheckById(string Id)
        {
            var query = orderList
                .Where(order => order.Id == Id);
            return query.ToList();
            throw new CanNotFindOrder($"没有ID为{Id}的订单");
        }
        //public void print()
        //{
        //    for (int i = 0; i < orderList.Count; i++)
        //    {
        //        Console.WriteLine($"名称：{orderList[i].Name}, 价格：{orderList[i].Price}， 数目：{orderList[i].Count}");
        //    }
        //}
        public List<Order> CheckOverTenThousand()
        {
            List<Order> list = orderList
                .Where(order => order.Amount > 10000)
                .Select(order => order)
                .ToList();
            return list;
        }
        public FileInfo Export(String fileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(OrderService));
            FileStream fs = new FileStream(fileName, FileMode.Create);
            xmlser.Serialize(fs, this);
            fs.Close();
            return new FileInfo(fileName);
        }

        public static OrderService Import(String fileName)
        {
            FileStream fs;
            fs = new FileStream(fileName, FileMode.Open);
            XmlSerializer xmlser = new XmlSerializer(typeof(OrderService));
            OrderService service = (OrderService)xmlser.Deserialize(fs);
            fs.Close();
            return service;
        }
        public FileInfo ExportHtml(String url)
        {
            try
            {
                this.Export("s.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load("s.xml");
                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();
                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load("s.xslt");
                XmlTextWriter writer = new XmlTextWriter(new FileStream(url, FileMode.Create), System.Text.Encoding.UTF8);
                xt.Transform(nav, null, writer);
            }
            catch (XmlException e)
            {
                Console.WriteLine("Exception caught:" + e.ToString());
            }
            catch (XsltException e)
            {
                Console.WriteLine("Exception caught:" + e.ToString());
            }
            return new FileInfo(url);
        }
    }
    
}

class CanNotFindOrder : ApplicationException
{
    public CanNotFindOrder(String message) : base(message) { }
}

