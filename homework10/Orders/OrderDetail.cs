using System;
using System.ComponentModel.DataAnnotations;

namespace Orders
{
    public class OrderDetail
    {
        [Key]
        public string Id { get; set; }
        public string Product { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public OrderDetail() {
          Id = Guid.NewGuid().ToString();
        }

        public OrderDetail(string id, string product, double unitPrice, int quantity) {
            Id = id;
            Product = product;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
        
    }
}