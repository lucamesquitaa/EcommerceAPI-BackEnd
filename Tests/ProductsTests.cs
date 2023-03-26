using EcommerceAPI.Controllers;
using EcommerceAPI.Facades;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class ProductsTests
    {
        ProductsController _controller;
        FakeProducts _repository;
        public ProductsTests()
        {
            _repository = new FakeProducts();
            _controller = new ProductsController(_repository);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAll().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Products>>(okResult.Value);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetById(1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.AddProduct(new Products()
            {
                Title = "titlex",
                Category = "celx",
                Photo = "photox",
                Price = 4365,
                Available = 400
            });
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Put_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.EditProduct(2, 12);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Delete_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.DeleteProduct(5);
            // Assert
            Assert.IsType<OkResult>(okResult.Result);
        }

        [Fact]
        public void Put_WhenWrongRequested_ReturnsBadRequest()
        {
            // Act
            var badResult = _controller.EditProduct(2, 3000);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResult.Result);
        }

        [Fact]
        public void Post_WhenNullName_ReturnsBadrequest()
        {
            // Act
            var badResult = _controller.AddProduct(new Products()
            {
                Category = "celx",
                Photo = "photox",
                Price = 4365,
                Available = 400
            });
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResult.Result);
        }
    }
}
