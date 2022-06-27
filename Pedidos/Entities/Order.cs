using System;
using System.Text;
using System.Collections.Generic;
using Pedidos.Entities.Enums;
using System.Globalization;

namespace Pedidos.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Orders { get; set; } = new List<OrderItem>();

        Order()
        {
        }

        public Order(OrderStatus status, Client client)
        {
            Moment = DateTime.Now;
            Status = status;
            Client = client;
        }

        public void AddITem(OrderItem item)
        {
            Orders.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Orders.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Orders)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMARY:");
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy"));
            sb.AppendLine("Order status: " + Status);
            sb.Append("Client: " + Client.Name);
            sb.Append(" (" + Client.BithDate + ") ");
            sb.AppendLine("- " + Client.Email);
            sb.AppendLine("Order items:");
            foreach (var item in Orders)
            {
                sb.Append(item.Product.Name + ", ");
                sb.Append("Quantity: " + item.Quantity + ", ");
                sb.AppendLine("Subtotal: $" + item.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
