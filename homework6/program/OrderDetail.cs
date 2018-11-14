using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program
{
    [Serializable]
    public class OrderDetail
    {
        public double price;
        public OrderDetail() { }
        public OrderDetail(string id, string product, uint quantity, double price)
        {
            this.Quantity = quantity;
            this.Id = id;
            this.Product = product;
            this.Price = price;
        }
        public string Id { get; set; }
        public uint Quantity { get; set; }
        public string Product { get; set; }
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value must >= 0!");
                price = value;
            }
        }
        public override string ToString()
        {
            string result = "";
            result += $"orderDetailId:{Id}:  ";
            result += $", quantity:{Quantity}";
            return result;
        }
    }
}
