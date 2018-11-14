using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    [Serializable]
    public class Order
    {
        private List<OrderDetail> details = new List<OrderDetail>();
        public string Id { get; set; }
        public string PhoneNum { get; set; }
        public string Client { get; set; }
        private static int uid = 0;
        public Order()
        {
            DateTime dateTime = DateTime.Now;
            SetId();
            
            if (uid < 999)
            {
                uid++;
            }
        }
        public Order(string id, string client)
        {
            this.Client = client;
            this.Id = id;
            SetId();
            if (uid < 999)
            {
                uid++;
            }
        }
        public double Amount
        {
            get
            {
                return details.Sum(d => d.Price * d.Quantity);
            }
        }
        public List<OrderDetail> Details
        {
            get => this.details;
        }
        private void SetId()
        {
            DateTime dateTime = DateTime.Now;
            Id = dateTime.ToString("yyyyMMdd");
            if (uid < 10)
            {
                Id = Id + "00" + uid.ToString();
            }
            else if (uid < 100)
            {
                Id = Id + "0" + uid.ToString();
            }
            else
            {
                Id = Id + uid.ToString();
            }
        }
        public void AddDetails(OrderDetail orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
        }
        public void RemoveDetails(string orderDetailId)
        {
            details.RemoveAll(d => d.Id == orderDetailId);
        }
        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{Id}, client:({Client}),Amount:{Amount}";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
    }
}
