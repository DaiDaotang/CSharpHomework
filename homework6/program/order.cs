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
        public uint Id { get; set; }
        public string Client { get; set; }
        public Order() { }
        public Order(uint id, string client)
        {
            this.Client = client;
            this.Id = id;
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
        public void AddDetails(OrderDetail orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
        }
        public void RemoveDetails(uint orderDetailId)
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
