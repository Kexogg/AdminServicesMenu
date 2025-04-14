using AdminServicesMenu.Core.Models;
using AdminServicesMenu.Core.Services;
using AdminServicesMenu.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AdminServicesMenu.Tests
{
    [TestFixture]
    public class PresetsControllerTests
    {
        private Mock<IPresetService> _mockPresetService;
        private const string Id = "testid";

        private PresetController _controller;

        [SetUp]
        public void Setup()
        {
            _mockPresetService = new Mock<IPresetService>();
            _controller = new PresetController(_mockPresetService.Object);
        }

        [Test]
        public void GetCurrentPreset_ShouldReturnOkResult()
        {
            var result = _controller.GetCurrentPreset(Id);

            Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void GetPresets_ShouldReturnOkResult()
        {
            var result = _controller.GetPresets();

            Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void CreatePreset_ShouldReturnOkResult()
        {
            var dummyPreset = new PresetCreateDTO();
            var result = _controller.CreatePreset(dummyPreset);

            Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void UpdatePreset_ShouldReturnOkResult()
        {
            var dummyPreset = new PresetUpdateDTO();
            var result = _controller.UpdatePreset(Id, dummyPreset);

            Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void DeletePreset_ShouldReturnOkResult()
        {
            var result = _controller.DeletePreset(Id);

            Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        }
    }
}