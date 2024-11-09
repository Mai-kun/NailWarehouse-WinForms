using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NailWarehouse.Contracts;
using NailWarehouse.Contracts.Models;
using Xunit;

namespace NailWarehouse.ProductManager.Tests
{
    public class ProductManagerTests
    {
        private readonly IProductManager productManager;
        private readonly Mock<IProductStorage> productStorageMock;
        private readonly Mock<ILogger> loggerMock;

        public ProductManagerTests()
        {
            productStorageMock = new Mock<IProductStorage>();
            loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()));


            productManager = new ProductsManager(productStorageMock.Object, loggerMock.Object);
        }

        [Fact]
        public async Task AddAsyncShouldWork()
        {
            // Arrange
            var model = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "qwe",
                Size = 2,
                Material = Materials.Copper.ToString(),
                Quantity = 11,
                MinimumQuantity = 1,
                Price = 10,
            };

            productStorageMock.Setup(x => x.AddAsync(It.IsAny<Product>()))
                .ReturnsAsync(model);

            // Act
            var result = await productManager.AddAsync(model);

            // Assert
            result.Should().NotBeNull().And.Be(model);
            productStorageMock.Verify(x => x.AddAsync(It.Is<Product>(y => y.Id == model.Id)), Times.Once);
            productStorageMock.VerifyNoOtherCalls();
            loggerMock.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Exactly(2));
        }
    }
}
