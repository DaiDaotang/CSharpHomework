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
        public OrderDetail(uint id, string name, uint quantity, double price)
        {
            this.Quantity = quantity;
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }
        public uint Id { get; set; }
        public uint Quantity { get; set; }
        public string Name { get; set; }
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
