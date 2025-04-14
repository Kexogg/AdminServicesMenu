using AdminServicesMenu.WebApi.Controllers;
using AdminServicesMenu.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminServicesMenu.Tests
{
    [TestFixture]
    public class PresetsControllerTests
    {
        private const string Id = "testid";

        private PresetController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new PresetController();
        }

        [Test]
        public void GetCurrentPreset_ShouldReturnOkResult()
        {
            ActionResult<PresetDTO> result = _controller.GetCurrentPreset(Id);

            Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void GetAllPresets_ShouldReturnOkResult()
        {
            ActionResult<PresetDTO> result = _controller.GetAllPresets();

            Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void CreatePreset_ShouldReturnOkResult()
        {
            ActionResult<PresetDTO> result = _controller.CreatePreset();

            Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void UpdatePreset_ShouldReturnOkResult()
        {
            var dummyPreset = new PresetDTO();
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