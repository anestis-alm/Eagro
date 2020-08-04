using eagro.Models;
using eagro.Options;
using eagro.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eagro.Services
{
    public class BasketManagement : IBasketManager
    {
        private EagroDbContext db;

        public BasketManagement(EagroDbContext _db)
        {
            db = _db;
        }

        public Basket CreateBasket(BasketOption baskOption)
        {
            CustomerManagement cstMng = new CustomerManagement(db);
            Basket basket = new Basket
            {
                Customer = cstMng.FindCustomerById(baskOption.CustomerId),
            };

            db.Baskets.Add(basket);
            db.SaveChanges();
            return basket;
        }

        public BasketProduct AddProduct(BasketProductOption bskProd)
        {
            BasketProduct basketProduct = new BasketProduct
            {
                ProdQuantity = bskProd.ProdQuantity,
                ProdPrice = EachProductCost(bskProd.ProductId, bskProd.ProdQuantity),
                Basket = db.Baskets.Find(bskProd.BasketId),
                Product = db.Products.Find(bskProd.ProductId)
            };

            db.BasketProducts.Add(basketProduct);
            db.SaveChanges();


            return basketProduct;
        }

       public BasketProduct BasketProdUpdate(BasketProductOption bskProdOption, int bskProdId)
       {
            BasketProduct basketProduct = db.BasketProducts.Find(bskProdId);

            if (bskProdOption.ProdQuantity > 0)
                basketProduct.ProdQuantity = bskProdOption.ProdQuantity;
            else if (bskProdOption.ProdQuantity == 0)
                RemoveProduct(bskProdId);

            db.SaveChanges();
            return basketProduct;
       }

        public Basket FindBasketById(int basketId)
        {
            return db.Baskets
                .Include(basket => basket.BasketProducts)
                .Where(basket => basket.Id == basketId)
                .First();
        }

        public List<Basket> FindCustomerBaskets(int custId)
        {
            return db.Baskets
                .Where(basket => basket.Customer.Id == custId)
                .ToList();
        }

        public bool RemoveProduct(int bskProdId)
        {

            BasketProduct bskProd = db.BasketProducts.Find(bskProdId);

            if (bskProd != null)
            {
                db.BasketProducts.Remove(bskProd);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public decimal TotalBasketCost(int basketId)
        {
            Basket basket = FindBasketById(basketId);

            List<BasketProduct> bskPrds = db.BasketProducts
                .Where(bskPrds => bskPrds.Basket.Id == basketId)
               .ToList();

            decimal total_am = 0;
            foreach (BasketProduct bP in bskPrds)
            {
                total_am += bP.ProdPrice;
            }

            return total_am;
        }

        public decimal EachProductCost(int prodId, decimal prodQuantity)
        {
            Product product = db.Products.Find(prodId);

            decimal price = 0;
            price = product.Price * prodQuantity;

            return price;
        }
    }
}
