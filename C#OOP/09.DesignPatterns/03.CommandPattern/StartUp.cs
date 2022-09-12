namespace CommandPatternDemo
{
    public class StartUp
    {
        public static void Main()
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("Izvara", 4);

            Execute(product,modifyPrice, new ProductCommand(product, PriceAction.Increase, 1));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 2));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 4));

            System.Console.WriteLine(product);
        }
        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
