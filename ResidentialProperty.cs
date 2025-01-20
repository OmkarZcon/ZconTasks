namespace RealEstate.Core.models
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