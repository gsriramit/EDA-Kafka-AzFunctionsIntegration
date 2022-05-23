using System;
using System.Collections.Generic;
using System.Text;

namespace EventStreamingApp.Models
{
    public class OrderEventModel
    {
        public long ordertime { get; set; }
        public int orderid { get; set; }
        public string itemid { get; set; }
        public float orderunits { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }
    }

}
