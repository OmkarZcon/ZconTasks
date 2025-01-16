using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTaskDay2
{
    public class ResidentialProperty : Property
    {
       
        public ResidentialProperty(int propertyId, string address, decimal price) : base(propertyId, address, price)
        {
        }


        public override string GetDetails()
        {
            return $"Residential Property - Address: {Address}, Price: {Price:C}";
        }
    }

}
