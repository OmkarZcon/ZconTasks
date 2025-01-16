namespace OOPTaskDay2
{
    public class CommercialProperty : Property
    {
        public CommercialProperty(int propertyId, string address, decimal price)
            : base(propertyId, address, price)
        {
        }

      
        public override string GetDetails()
        {
            return $"Commercial Property - Address: {Address}, Price: {Price:C}";
        }
    }

}
