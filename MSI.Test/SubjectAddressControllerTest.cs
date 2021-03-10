using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSI.API.Controllers;
using MSI.API.Dtos;
using MSI.API.Services;
using System.Collections.Generic;
using Xunit;

namespace MSI.Test
{
    public class SubjectAddressControllerTest
    {
        private readonly SubjectAddressController _subjectAddressController;
        private readonly IContactRepository _contactRepository;
        private readonly ILogger<SubjectAddressController> _logger;
        readonly ILoggerFactory loggerFactory;

        public SubjectAddressControllerTest()
        {
            loggerFactory = new LoggerFactory();
            _logger = loggerFactory.CreateLogger<SubjectAddressController>();
            _contactRepository = new InMemoryContactRepository();
            _subjectAddressController = new SubjectAddressController(_logger, _contactRepository);
        }

        [Fact]
        public void Get_Returns_OkResult()
        {
            // Act
            var okResult = _subjectAddressController.GetAllSubjectAddresses();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_Returns_2Items()
        {
            // Act
            var response = _subjectAddressController.GetAllSubjectAddresses();

            //Arrange
            var result = response.Result as OkObjectResult;
            var items = result.Value as IList<SubjectAddressDto>;
            // Assert
            Assert.Equal(2, items.Count);
        }
    }
}
