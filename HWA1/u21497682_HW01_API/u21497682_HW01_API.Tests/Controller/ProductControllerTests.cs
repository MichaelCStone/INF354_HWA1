using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using u21497682_HW01_API.Controllers;
using u21497682_HW01_API.Models;
using u21497682_HW01_API.Repositories;
using Xunit;

namespace u21497682_HW01_API.Tests.Controller
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _controller = new ProductController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllProducts_ReturnsOkResult_WithListOfProducts() //returns an HTTP 200 OK response with a list of products.
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Product_ID = 1, Product_Name = "Shoe", Product_Description = "A running shoe", Product_Price = 50 },
                new Product { Product_ID = 2, Product_Name = "Boot", Product_Description = "A leather boot", Product_Price = 80 }
            };

            _mockRepo.Setup(repo => repo.GetAllProducts()).ReturnsAsync(products);

            // Act
            var result = await _controller.GetAllProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProducts = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.NotNull(returnedProducts);
            Assert.Equal(2, returnedProducts.Count());
        }

        [Fact]
        public async Task GetProductById_ReturnsOkResult_WhenProductExists() //returns an HTTP 200 OK response when the product exists
        {
            // Arrange
            var product = new Product { Product_ID = 1, Product_Name = "Shoe", Product_Description = "A running shoe", Product_Price = 50 };

            _mockRepo.Setup(repo => repo.GetProductById(1)).ReturnsAsync(product);

            // Act
            var result = await _controller.GetProductById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProduct = Assert.IsType<Product>(okResult.Value);
            Assert.NotNull(returnedProduct);
            Assert.Equal(1, returnedProduct.Product_ID);
        }

        [Fact]
        public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExist() //returns a 404 Not Found when the product does not exist.
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetProductById(99)).ReturnsAsync((Product?)null);

            // Act
            var result = await _controller.GetProductById(99);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
