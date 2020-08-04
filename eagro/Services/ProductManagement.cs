using eagro.Models;
using eagro.Options;
using eagro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eagro.Services
{
    public class ProductManagement : IProductManager
    {
        private EagroDbContext db;

        public ProductManagement(EagroDbContext _db)
        {
            db = _db;
        }

        public Product CreateProduct(ProductOption prodOption)
        {
                Product product = new Product
                {
                    Name = prodOption.Name,
                    Description = prodOption.Description,
                    Price = prodOption.Price,
                    Category = prodOption.Category,
                    Quantity = prodOption.Quantity,
                    ThemeImage = prodOption.ThemeImage,
                    Available = true
                };


                db.Products.Add(product);
                db.SaveChanges();

                return product;
        }

        public Product FindProductById(int prodId)
        {
            return db.Products.Find(prodId);
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }



        public Product Update(ProductOption prodOption, int prodId)
        {
            Product product = FindProductById(prodId);
            if (prodOption.Name != null)
                product.Name = prodOption.Name;
            if (prodOption.Description != null)
                product.Description = prodOption.Description;
            if (prodOption.Price > 0)
                product.Price = prodOption.Price;
            if (prodOption.Category != null)
                product.Category = prodOption.Category;
            if (prodOption.Quantity > 0 )
            {
                product.Quantity = prodOption.Quantity;
                product.Available = true;
            }
            if (!string.IsNullOrWhiteSpace(prodOption.ThemeImage))
                product.ThemeImage = prodOption.ThemeImage;
            

            db.SaveChanges();
            return product;
        }

        public void AvailableQuantity(int basketId)
        {
            List<Product> prds = db.Products.ToList();


            List<BasketProduct> bskPrds = db.BasketProducts
                .Where(bskPrds => bskPrds.Basket.Id == basketId)
               .ToList();

            foreach (Product pr in prds)
            {
                foreach (BasketProduct bp in bskPrds)
                {
                    if (bp.Product.Id == pr.Id)
                    {
                        Product product = db.Products.Find(bp.Product.Id);
                        product.Quantity = pr.Quantity - bp.ProdQuantity;
                        if (product.Quantity <= 0 )
                        {
                            product.Available = false;
                        }
                        db.Products.Update(product);
                        db.SaveChanges();
                    }
                }
            }
        }

    }
}

