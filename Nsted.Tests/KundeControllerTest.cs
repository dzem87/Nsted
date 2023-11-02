using Microsoft.AspNetCore.Mvc;
using Nsted.Controllers;
using Nsted.Models;
using Nsted.Repositories;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace YourProject.Tests
{
    public class KundeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var context = Substitute.For<NstedDbContext>();
            var controller = new KundeController(context);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<Index>(result);
        }

        [Fact]
        public void IndexPost_WithValidModel_RedirectsToList()
        {
            // Arrange
            var context = Substitute.For<NstedDbContext>();
            var controller = new KundeController(context);
            var validKunde = new Kunde(); // Create a valid Kunde object

            // Act
            var result = controller.Index(validKunde) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("List", result.ActionName);
        }

        [Fact]
        public void IndexPost_WithInvalidModel_ReturnsViewResult()
        {
            // Arrange
            var context = Substitute.For<NstedDbContext>();
            var controller = new KundeController(context);
            var invalidKunde = new Kunde();
            controller.ModelState.AddModelError("SomeProperty", "Some error message");

            // Act
            var result = controller.Index(invalidKunde);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        public async Task PostvaluesToRepository()
        {
            var kundeRepository = Substitute.For<IKundeRepository>();
            var UnitUnderTest = new KundeController(kundeRepository);
            KundeRepository.GetAlll().Returns(new List<Kudnde> {new Kunde { })

            UnitUnderTest.Add(new Kunde
            {
                UpsertModel = new Kunde
                {

                }
            });
            var sp = kundeRepository.ReceivedCalls().First().GetArguments().First() as Kunde;
        }

        // Add similar test methods for Delete, Edit, and EditPost actions.
    }
}
