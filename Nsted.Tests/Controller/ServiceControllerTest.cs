using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Nsted.Controllers;
using Nsted.Interfaces;
using Nsted.Models;
using Nsted.Repositories;

//Klasse som er skrevet ved bruk av XUnit for å teste metodene i ServiceController
//Bruker FakeItEasy for å mocke oppførselen til IServiceRepositoryen


namespace Nsted.Tests.Controller
{
   
    
        public class ServiceControllerTests
        {
            private ServiceController _serviceController;
            private IServiceRepository _serviceRepository;

            public ServiceControllerTests()
            {
                //Dependencies
                _serviceRepository = A.Fake<IServiceRepository>();

                //SUT
                _serviceController = new ServiceController(_serviceRepository);
            }

        [Fact]
        public void ServiceController_List_ReturnsSucess()
        {
            //Arrange
            var servicer = A.Fake<IEnumerable<Service>>();
            A.CallTo(() => _serviceRepository.GetAllAsync()).Returns(servicer);
            //Act 
            var result = _serviceController.List();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }


        [Fact]
        public void ServiceControler_Edit_ReturnsSucess()
        {
            //Arrange
            var id = 1;
            var service = A.Fake<Service>();
            A.CallTo(() => _serviceRepository.GetAsync(id)).Returns(service);
            //Act
            var result = _serviceController.Edit(id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public async Task ServiceController_Add_ReturnsRedirectToAction()
        {
            // Arrange
            var service = new Service();
            A.CallTo(() => _serviceRepository.AddAsync(service)).Returns(service);

            // Act
            var result = await _serviceController.Add(service) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("List", result.ActionName);
        }

        [Fact]
        public async Task ServiceController_Delete_ReturnsRedirectToAction()
        {
            // Arrange
            var id = 1;
            var service = new Service { ID = id };
            A.CallTo(() => _serviceRepository.DeleteAsync(id)).Returns(service);

            // Act
            var result = await _serviceController.Delete(service) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("List", result.ActionName);
        }
    }
    
}

