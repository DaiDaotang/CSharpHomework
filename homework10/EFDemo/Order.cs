using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    public class Order {
        [Key]
        public String Id { get; set; }
        public String Customer { get; set; }
        public string PhoneNum { get; set; }
        private static int uid = 0;
        public List<OrderDetail> Details { get; set; }

        
        public Order()
        {
            DateTime dateTime = DateTime.Now;
            SetId();
            Details = new List<OrderDetail>();
            if (uid < 999)
            {
                uid++;
            }
        }
        public Order(string id, string customer, List<OrderDetail> detail) {
            Id = id;
            Customer = customer;
            Details = detail;
            if (uid < 999)
            {
                uid++;
            }
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
    }
}
