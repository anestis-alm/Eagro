using eagro.Models;
using eagro.Options;
using System.Collections.Generic;

namespace eagro.Services
{
    public interface IProductManager
    {
        void AvailableQuantity(int basketId);
        Product CreateProduct(ProductOption prodOption);
        Product FindProductById(int prodId);
        List<Product> GetAll();
        Product Update(ProductOption prodOption, int prodId);
    }
}