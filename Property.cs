using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTaskDay2
{
    public abstract class Property
    {

        public int PropertyId { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }


        public Property(int propertyId, string address, decimal price)
        {
            PropertyId = propertyId;
            Address = address;
            Price = price;
        } 


        public abstract string GetDetails();
    }
}
