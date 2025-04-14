using AdminServicesMenu.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AdminServicesMenu.Tests
{

    [TestFixture]
    public class ServicesControllerTests
    {
        private const string Id = "testid";

        private ServiceController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new ServiceController();
        }

        [Test]
        public async Task GetAll_ShouldReturnOkResult()
        {
            var result = await _controller.GetAllServices();
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public async Task Get_ShouldReturnOkResult()
        {
            var result = await _controller.GetService(Id);
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public async Task Create_ShouldReturnOkResult()
        {
            var model = new { dummy = "value" };
            var result = await _controller.CreateService(model);
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public async Task Update_ShouldReturnOkResult()
        {
            var model = new { dummy = "value" };
            var result = await _controller.UpdateService(Id, model);
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public async Task Delete_ShouldReturnOkResult()
        {
            var result = await _controller.DeleteService(Id);
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }
    }
}