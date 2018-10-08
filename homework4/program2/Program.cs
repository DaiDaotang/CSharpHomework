using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Order order = new Order("招牌渔粉","ddt","01",9,1);
                Order newOrder = new Order("金汤渔粉", "ddt", "02", 10, 2);
                OrderService service = new OrderService();
                service.AddOrder(order);
                service.AddOrder(newOrder);
                service.DeleteByName("招牌渔粉");
                Order x = service.CheckById("02");
                //OrderDetails details = new OrderDetails();
                service.print();
                Console.ReadLine();
            }
            catch (CanNotFindOrder e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
    class Order
    {        
        private String name;
        private String client;
        private String id;
        private double price;
        private double count;
        public Order(String name = "", String client = "", String id = "", double price=0, double count=0)
        {          
            this.name = name;
            this.client = client;
            this.id = id;
            this.price = price;
            this.count = count;
        }
        public String Name { get => name; set => name = value; }
        public String Client { get => client; }
        public String Id { get => id; }
        public double Price { get => price; set => price = value; }
        public double Count { get => count; set => count = value; }
        
    }
    class OrderDetails
    {
        private String taste;
        private String hot;
        public OrderDetails(String taste, String hot)
        {
            this.taste = taste;
            this.hot = hot;
        }
    }
    class OrderService
    {
        private List<Order> orderList;
        public OrderService()
        {
            orderList = new List<Order>();
        }
        public void AddOrder(Order newOrder)
        {
            orderList.Add(newOrder);
        }
        public void DeleteById(String id)
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
        public void DeleteByName(String name)
        {
            bool find = false;
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].Name == name)
                {
                    orderList.Remove(orderList[i]);
                    find = true;
                }
            }
            if (!find)
            {
                throw new CanNotFindOrder($"没有名为{name}的订单");
            }
        }
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
        public Order CheckByName(String name)
        {
            foreach (Order order in orderList)
            {
                if (order.Name == name)
                {
                    return order;
                }
            }
            throw new CanNotFindOrder($"没有名为{name}的订单");
        }
        public List<Order> CheckByClient(String client)
        {
            List<Order> list = new List<Order>();
            foreach (Order order in orderList)
            {
                if (order.Client == client)
                {
                    list.Add(order);
                }
            }
            if (list.Count == 0)
            {
                throw new CanNotFindOrder($"没有客户为{client}的订单");
            }
            return list;
        }
        public Order CheckById(String Id)
        {
            foreach (Order order in orderList)
            {
                if (order.Id == Id)
                {
                    return order;
                }
            }
            throw new CanNotFindOrder($"没有ID为{Id}的订单");
        }
        public void print()
        {
            for (int i = 0; i < orderList.Count; i++)
            {
                Console.WriteLine($"名称：{orderList[i].Name}, 价格：{orderList[i].Price}， 数目：{orderList[i].Count}");
            }
        }

    }
    class CanNotFindOrder : ApplicationException
    {
        public CanNotFindOrder(String message) : base(message) { }
    }
    
}
