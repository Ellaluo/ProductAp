using System;
using Xunit;
using ProductApp.Models;
using ProductApp.Services;
using ProductApp.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProductAppTest.Controllers
{
    public class ProductsControllerTest
    {
        private readonly Mock<IProductService> _mockService;
        private readonly ProductsController _productcController;

        Product product1 = new Product()
        {
            Id = "1",
            Brand = "A",
            Description = "A",
            Model = "A"
        };
        Product product2 = new Product()
        {
            Id = "2",
            Brand = "B",
            Description = "B",
            Model = "B"
        };


        public ProductsControllerTest()
        {
            _mockService = new Mock<IProductService>();
            _productcController = new ProductsController(_mockService.Object);
        }

        [Fact]
        public async void GetList_ShouldReturnAllProducts()
        {

            var result = await _productcController.GetList();

            var objectResult = result.Result as OkObjectResult;
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async void Get_ShouldReturnProduct()
        {
            _mockService.Setup(s => s.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(product1));
            var result = await _productcController.Get("1");

            var objectResult = result.Result as OkObjectResult;
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async void Get_ShouldNotFindProduct()
        {
            _mockService.Setup(s => s.GetAsync(It.IsAny<string>())).Returns(Task.FromResult<Product>(null));
            var result = await _productcController.Get("1");

            var objectResult = result.Result as NotFoundResult;
            Assert.NotNull(objectResult);
            Assert.Equal(404, objectResult.StatusCode);
        }

        [Fact]
        public async void Create_ShouldReturnAllProducts()
        {
            var result = await _productcController.Create(product1);

        }

        [Fact]
        public async void Create_ShouldReturnConflict()
        {
            var result = await _productcController.Create(product1);
        }

        [Fact]
        public async void Update_ShouldReturnProduct()
        {
            _mockService.Setup(s => s.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(product1));
            product2.Id = product1.Id;
            _mockService.Setup(s => s.UpdateAsync(It.IsAny<Product>())).Returns(Task.FromResult(product1));
            var result = await _productcController.Update(product2);

            var objectResult = result.Result as OkObjectResult;
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async void Update_ShouldNotFindProducts()
        {
            _mockService.Setup(s => s.UpdateAsync(It.IsAny<Product>())).Returns(Task.FromResult(product2));
            var result = await _productcController.Update(product2);

            var objectResult = result.Result as NotFoundResult;
            Assert.NotNull(objectResult);
            Assert.Equal(404, objectResult.StatusCode);
        }

        [Fact]
        public async void Delete_ShouldDeleteProduct()
        {
            _mockService.Setup(s => s.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(product1));
            _mockService.Setup(s => s.DeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(1));

            var result = await _productcController.Delete("1");

            var objectResult = result as AcceptedResult;
            Assert.NotNull(objectResult);
            Assert.Equal(202, objectResult.StatusCode);
        }

        [Fact]
        public async void Delete_ShouldNotFindProduct()
        {
            _mockService.Setup(s => s.DeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(1));

            var result = await _productcController.Delete("1");

            var objectResult = result as NotFoundResult;
            Assert.NotNull(objectResult);
            Assert.Equal(404, objectResult.StatusCode);

        }
    }
}
