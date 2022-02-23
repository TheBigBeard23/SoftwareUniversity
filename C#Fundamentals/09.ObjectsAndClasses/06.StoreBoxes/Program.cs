using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            List<Box> boxes = new List<Box>();

            while (input!="end")
            {
                string[] data = input.Split();

                string serialNumber = data[0];
                string itemName = data[1];
                int itemQuantity = int.Parse(data[2]);
                decimal itemPrice = decimal.Parse(data[3]);
                decimal boxPrice = itemPrice * itemQuantity;

                Item currentItem = new Item(itemName, itemPrice);
                Box currentBox = new Box(serialNumber, currentItem, itemQuantity, boxPrice);

                boxes.Add(currentBox);

                input = Console.ReadLine();
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in boxes.OrderByDescending(x=>x.Price))
            {
                sb.AppendLine($"{item.SerialNumber}");
                sb.AppendLine($"-- {item.Item.Name} - ${item.Item.Price:f2}: {item.Quantity}");
                sb.AppendLine($"-- ${item.Price:f2}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
    public class Box
    {
        public string SerialNumber { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Item Item { get; set; }

        public Box(string serialNumber, Item item, int quantity, decimal price)
        {
            SerialNumber = serialNumber;
            Item = item;
            Quantity = quantity;
            Price = price;
        }
    }
}