using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindWeb.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int TotalRecords { get; set; }
    }
}