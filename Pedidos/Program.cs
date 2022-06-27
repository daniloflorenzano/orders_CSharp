using Pedidos.Entities;
using Pedidos.Entities.Enums;
using System;
using System.Globalization;

namespace Pedidos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime clientBirthDate = DateTime.Parse(Console.ReadLine());
            Client client = new Client(clientName, clientEmail, clientBirthDate);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());
            Order order = new Order(status, client);

            Console.Write("How many items to this order? ");
            int itemsQuantity = int.Parse(Console.ReadLine());

            for (int i = 0; i < itemsQuantity; i++)
            {
                Console.WriteLine($"Enter {i}# item data:");
                Console.Write("Product name: ");
                string orderName = Console.ReadLine();
                Console.Write("Product price: ");
                double orderPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int orderQuantity = int.Parse(Console.ReadLine());

                Product product = new Product(orderName, orderPrice);
                OrderItem orderItem = new OrderItem(orderQuantity, orderPrice, product);
                order.AddITem(orderItem);
            }
            
            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}
