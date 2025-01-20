using OOPTaskDay2;
namespace RealEstate.Core.models;

public class InvalidPriceException : Exception
{
    public InvalidPriceException(string message) : base(message) { }
}


class Program


{

  
    static void Main()
    {



        // Create lists to store properties
        List<Property> properties = new List<Property>();

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






            // Exception Handling for Price
            decimal price;
             
            try 
            {
                Console.Write("Enter Price: ");
                price = decimal.Parse(Console.ReadLine());

                if (price <= 0)
                {
                    throw new InvalidPriceException("Price must be greater than 0.");
                }
            }
            catch (FormatException ex)
            {
                
                FileLogger.Log($"FormatException Caught: {ex.Message}");
                FileLogger.Log($"Stack Trace: {ex.StackTrace}");

                Console.WriteLine("Invalid price. Please enter a valid number.");
                i--;
                continue;
            }
            catch (InvalidPriceException ex)
            {
               
                FileLogger.Log($"InvalidPriceException Caught: {ex.Message}");
                FileLogger.Log($"Stack Trace: {ex.StackTrace}");

                Console.WriteLine("Enter number greater than 0"); 
                i--;
                continue;
            }




            // Create property object
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





        // Prints the details of the properties ( Reflections )
        PropertyInspector.TestReflection();




        Console.Write("\nEnter the minimum price to filter properties: ");
        decimal minPrice = decimal.Parse(Console.ReadLine());

        var filteredProperties = properties.Where(p => p.Price >= minPrice);

        Console.WriteLine($"\nProperties with price >= {minPrice:C}:");
        foreach (var property in filteredProperties)
        {
            Console.WriteLine(property.GetDetails());
        }



        // Grouping properties by type
        var groupedProperties = properties.GroupBy(p => p.GetType().Name);

        Console.WriteLine("\nProperties grouped by type:");
        foreach (var group in groupedProperties)
        {
            Console.WriteLine($"\n{group.Key}:");
            foreach (var property in group)
            {
                Console.WriteLine($"  - {property.Address}, Price: {property.Price:C}");
            }
        }



    }
}


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