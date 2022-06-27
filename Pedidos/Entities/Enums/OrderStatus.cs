namespace Pedidos.Entities.Enums
{
    enum OrderStatus : int
    {
        PedingPayment,
        Processing = 1,
        Shipped = 2,
        Delivered = 3,
    }
}
