using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Collections;
using mix_coffeeshop_web.Models;
using Moq;
using Xunit;

namespace mix_coffeeshop_web_test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Get products with correct data Then system return all products.")]
        public void GetAllProductSuccess()
        {
            var mock = new MockRepository(MockBehavior.Default);
            var repo = mock.Create<mix_coffeeshop_web.Models.IProductRepository>();
            var api = new mix_coffeeshop_web.Controllers.ProductController(repo.Object);
            repo.Setup(it => it.GetAllProducts()).Returns(()=> new List<Product>
            {
                new Product(),
                new Product(),
                new Product(),
                new Product(),
            });
            var products = api.Get();
            products.Should().HaveCount(4);
        }

        [Fact(DisplayName = "Get products when no products in the system Then system return 0 product.")]
        public void GetAllProductWhenNoDataInTheStorage()
        {
            var mock = new MockRepository(MockBehavior.Default);
            var repo = mock.Create<mix_coffeeshop_web.Models.IProductRepository>();
            var api = new mix_coffeeshop_web.Controllers.ProductController(repo.Object);
            repo.Setup(it => it.GetAllProducts()).Returns(()=> new List<Product>
            {
            });
            var products = api.Get();
            products.Should().HaveCount(0);
        }

        /*
        Get all products

        Normal cases
        1. Get products with correct data Then system return all products.
        2. Get products when no products in the system Then system return 0 product.

        Alternative cases
        3. Get products with unknow category Then system return 0 product.
        4. Get products with no privilege Then system show an error message.

        Exception cases
        5. Get products but can't connect to the server Then system show an error message.
         */

    }
}