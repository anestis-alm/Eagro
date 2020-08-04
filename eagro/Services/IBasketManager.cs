using eagro.Models;
using eagro.Options;
using System.Collections.Generic;

namespace eagro.Services
{
    public interface IBasketManager
    {
        BasketProduct AddProduct(BasketProductOption bskProd);
        Basket CreateBasket(BasketOption baskOption);
        Basket FindBasketById(int basketId);
        List<Basket> FindCustomerBaskets(int custId);
        bool RemoveProduct(int bskProdId);
        public BasketProduct BasketProdUpdate(BasketProductOption bskProdOption, int bskProdId);
        decimal TotalBasketCost(int basketId);
    }
}