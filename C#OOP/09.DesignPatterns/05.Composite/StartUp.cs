using System;

namespace CompositeDemo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("Iphone", 2300);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            var rootBox = new CompositeGift("RootBox", 0);
            var truckToy = new SingleGift("Truck", 200);
            var plainToy = new SingleGift("Plain", 400);
            rootBox.Add(truckToy);
            rootBox.Add(plainToy);
            rootBox.Add(phone);

            var childBox = new CompositeGift("ChildBox", 0);
            var soldierToy = new SingleGift("Soldier", 100);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
        }
    }
}
