using OOPTaskDay2;

class Program
{
    static void Main()
    {
        // Create lists to store properties
        List<Property> properties = new List<Property>();

        // Get number of properties to add
        Console.Write("Enter the number of properties to add: ");
        int propertyCount = int.Parse(Console.ReadLine());

        // Input loop for properties
        for (int i = 0; i < propertyCount; i++)
        {
            Console.WriteLine($"\nProperty #{i + 1}");
            Console.Write("Enter property type (1 for Residential, 2 for Commercial): ");
            int propertyType = int.Parse(Console.ReadLine());

            Console.Write("Enter Property ID: ");
            int propertyId = int.Parse(Console.ReadLine());

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            // Create appropriate property object based on type
            Property property;
            if (propertyType == 1)
            {
                property = new ResidentialProperty(propertyId, address, price);
            }
            else
            {
                property = new CommercialProperty(propertyId, address, price);
            }

            // Add to list
            properties.Add(property);
        }

        // Create printer object
        var propertyPrinter = new PropertyPrinter();

        // Display all properties
        Console.WriteLine("\n=== Property Details ===");
        foreach (var property in properties)
        {
            var details = property.GetDetails();
            propertyPrinter.PrintPropertyDetails(details);

            // Calculate and display tax for each property
            decimal propertyPrice = property.Price;
            decimal propertyTax;

            PropertyTaxCalculator.CalculateTax(ref propertyPrice, out propertyTax);
            var taxDetails = propertyPrinter.PrintTaxDetails(propertyPrice, propertyTax);
            Console.WriteLine(taxDetails);
            Console.WriteLine("------------------------");
        }

        // Calculate total portfolio value
        decimal totalValue = properties.Sum(p => p.Price);
        Console.WriteLine($"\nTotal Portfolio Value: {totalValue:C}");

        // Property type statistics
        int residentialCount = properties.Count(p => p is ResidentialProperty);
        int commercialCount = properties.Count(p => p is CommercialProperty);

        Console.WriteLine($"\nPortfolio Statistics:");
        Console.WriteLine($"Total Properties: {properties.Count}");
        Console.WriteLine($"Residential Properties: {residentialCount}");
        Console.WriteLine($"Commercial Properties: {commercialCount}");
    }
}

// PropertyPrinter Class remains the same
public class PropertyPrinter
{
    public void PrintPropertyDetails(string propertyDetails)
    {
        Console.WriteLine($"Property Details: {propertyDetails}");
    }

    public string PrintTaxDetails(decimal price, decimal tax)
    {
        return $"Updated Price: {price:C}, Tax Amount: {tax:C}";
    }
}