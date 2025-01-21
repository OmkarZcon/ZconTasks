using System.Reflection;

namespace RealEstate.Core.models
{
    public static class PropertyInspector
    {
       
       
        public static void ListClassProperties(Type type)
        {
            Console.WriteLine($"Properties of class {type.Name}:");
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                Console.WriteLine($"- {property.Name} ({property.PropertyType.Name})");
            }
        }

       
        public static void TestReflection()
        {
            Console.WriteLine("\n=== Property Reflections ===");
            Console.WriteLine("ResidentialProperty Properties:");
            ListClassProperties(typeof(ResidentialProperty));


            Console.WriteLine("\nCommercialProperty Properties:");
            ListClassProperties(typeof(CommercialProperty));
        }
    }
}
