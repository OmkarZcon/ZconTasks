namespace OOPTaskDay2
{
    public static class PropertyTaxCalculator
    {
        
        public static void CalculateTax(ref decimal price, out decimal taxAmount)
        {
            
            decimal taxRate = 0.05m;

            taxAmount = price * taxRate;

          
            price = price + taxAmount;
        }
    }
}
