using eagro.Models;
using eagro.Options;
using eagro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eagro.Services
{
    public class OrderManagement : IOrderManager
    {
        private EagroDbContext db;

        public OrderManagement(EagroDbContext _db)
        {
            db = _db;
        }

        public Order CreateOrder(OrderOption orderOption)
        {
            BasketManagement bskMng = new BasketManagement(db);
            ProductManagement prdMng = new ProductManagement(db);
            CustomerManagement cstMng = new CustomerManagement(db);
            Order order = new Order
            {
                Basket = bskMng.FindBasketById(orderOption.BasketId),
                Customer = cstMng.FindCustomerById(orderOption.CustomerId),
                OrderName = orderOption.OrderName,
                OrderAddress = orderOption.OrderAddress,
                OrderCity = orderOption.OrderCity,
                OrderState = orderOption.OrderState,
                OrderCountry = orderOption.OrderCountry,
                OrderPhone = orderOption.OrderPhone,
                OrderEmail = orderOption.OrderEmail,
                OrderCost = bskMng.TotalBasketCost(orderOption.BasketId),
                OrderDate = DateTime.Now,
                OrderShipped = false,
                OrderTrackingNumber = ""
            };


            db.Orders.Add(order);
            db.SaveChanges();

            prdMng.AvailableQuantity(orderOption.BasketId);

            return order;
        }

        public Order FindOrderById(int orderId)
        {
            return db.Orders.Find(orderId);
        }

        public List<Order> FindOrderByCustomer(OrderOption orderOption)
        {
            if (orderOption == null) return null;
            if (orderOption.OrderName == null) return null;

            return db.Orders
                .Where(ord => ord.OrderName == orderOption.OrderName)
                .ToList();
        }

        public Order OrderUpdate(Order orderOption, int orderId)
        {
            Order order = FindOrderById(orderId);

            if (orderOption.OrderName != null)
                order.OrderName = orderOption.OrderName;
            if (orderOption.OrderAddress != null)
                order.OrderAddress = orderOption.OrderAddress;
            if (orderOption.OrderCity != null)
                order.OrderCity = orderOption.OrderCity;
            if (orderOption.OrderState != null)
                order.OrderState = orderOption.OrderState;
            if (orderOption.OrderCountry != null)
                order.OrderCountry = orderOption.OrderCountry;
            if (orderOption.OrderPhone != null)
                order.OrderPhone = orderOption.OrderPhone;
            if (orderOption.OrderEmail != null)
                order.OrderEmail = orderOption.OrderEmail;

            order.OrderShipped = orderOption.OrderShipped;

            if (orderOption.OrderTrackingNumber != null)
                order.OrderTrackingNumber = orderOption.OrderTrackingNumber;

            db.SaveChanges();
            return order;
        }

        public bool DeleteOrder(int orderId)
        {
            Order order = FindOrderById(orderId);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
                return true;

            }
            return false;
        }

    }
}
