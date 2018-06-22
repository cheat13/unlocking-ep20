using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mix_coffeeshop_web.Models;

namespace mix_coffeeshop_web.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        public static IList<Product> products = new List<Product>
        {
            new Product{ Id = 1, Name = "Hot Coffee", Price = 50, ThumbURL = "/images/hot-coffee.png" },
            new Product{ Id = 2, Name = "Cheese Cake", Price = 60, ThumbURL = "/images/cheese-cake.png" },
            new Product{ Id = 3, Name = "Chocolate Cake", Price = 70, ThumbURL = "/images/chocolate-cake.png" },
            new Product{ Id = 4, Name = "Crepe Cake", Price = 80, ThumbURL = "/images/crepe-cake.png" },
            new Product{ Id = 5, Name = "Ice Coffee", Price = 90, ThumbURL = "/images/ice-coffee.png" },
            new Product{ Id = 6, Name = "Panna Cotta", Price = 100, ThumbURL = "/images/panna-cotta.png" },
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var repo = new ProductRepository();
            var products = repo.GetAllProducts();
            return products;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return products.FirstOrDefault(it => it.Id == id);
        }

        [HttpPost]
        public Product CreateNewProduct([FromBody]Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return product;
        }

        [HttpPut]
        public Product UpdateProduct([FromBody]Product product)
        {
            var selectedProduct = products.FirstOrDefault(it => it.Id == product.Id);
            selectedProduct.Name = product.Name;
            selectedProduct.Price = product.Price;
            selectedProduct.Desc = product.Desc;
            selectedProduct.ThumbURL = product.ThumbURL;
            return selectedProduct;
        }
    }
}
