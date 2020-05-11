using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MVCCoreApp.Abstractions;
using MVCCoreApp.Data.Dtos;
using MVCCoreApp.Data.Models;
using Xunit;
using Xunit.Abstractions;

namespace MvcCoreAppTests
{
    public class ProductsControllerShould
    {
        static HttpClient _client = new HttpClient();
        private readonly ITestOutputHelper _output;
        private readonly IRepository<Product> _repository;

        public ProductsControllerShould(ITestOutputHelper output, IRepository<Product> repository)
        {
            _output = output;
            _repository = repository;
        }

        [Fact]
        public async Task ProductIsCreated()
        {
            var createModel = new ProductDto
            {
                Name = "Test Name",
                Description = "Test Description",
                Category = "Test Category",
                Manufacturer = "Test Manufacturer",
                Supplier = "Test Supplier",
                Price = 10
            };

            var url = "https://localhost:44334/products/create";
            var response = await _client.PostAsJsonAsync(url, createModel);
            await response.EnsureSuccessStatusCode(_output);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var content = await response.Content.ReadDynamicAsJsonAsync();
            var id = (Guid)content.id;
            var stored = await _repository.GetAsync(id);
            Assert.NotNull(stored);
            Assert.Equal(createModel.Name, stored.Name);
            Assert.Equal(createModel.Description, stored.Description);
            Assert.Equal(createModel.Category, stored.Category);
            Assert.Equal(createModel.Manufacturer, stored.Manufacturer);
            Assert.Equal(createModel.Supplier, stored.Supplier);
            Assert.Equal(createModel.Price, stored.Price);
        }
    }
}
