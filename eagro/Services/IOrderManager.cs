using eagro.Models;
using eagro.Options;
using System.Collections.Generic;

namespace eagro.Services
{
    public interface IOrderManager
    {
        Order CreateOrder(OrderOption orderOption);
        bool DeleteOrder(int orderId);
        List<Order> FindOrderByCustomer(OrderOption orderOption);
        Order FindOrderById(int orderId);
        Order OrderUpdate(Order orderOption, int orderId);
    }
}