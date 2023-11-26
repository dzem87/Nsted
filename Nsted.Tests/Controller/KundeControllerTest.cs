
using Microsoft.AspNetCore.Mvc;
using Nsted.Controllers;
using Nsted.Models;
using NSubstitute;
using System.Collections.Generic;
using Xunit;
using FakeItEasy;
using FluentAssertions;
using Nsted.Interfaces;

//Klasse som er skrevet ved bruk av XUnit for å teste metodene i KundeController
//Bruker FakeItEasy for å mocke oppførselen til IKundeRepositoryen

namespace Nsted.Tests.Controller
{
    public class KundeControllerTests
    {
        private KundeController _kundeController;
        private IKundeRepository _kundeRepository;

        public KundeControllerTests()
        {
            //Dependencies
            _kundeRepository = A.Fake<IKundeRepository>();

            //SUT
            _kundeController = new KundeController (_kundeRepository);
        }

        [Fact]
        public void KundeController_List_ReturnsSucess()
        {
            //Arrange
            var kunder = A.Fake<IEnumerable<Kunde>>();
            A.CallTo(() =>_kundeRepository.GetAllAsync()).Returns(kunder);
            //Act 
            var result = _kundeController.List();
            //Assert
            result.Should().BeOfType< Task < IActionResult >> ();
        }

        [Fact]
        public void KundeControler_Edit_ReturnsSucess()
        {
            //Arrange
            var id = 1;
            var kunde = A.Fake<Kunde>();
            A.CallTo(()=>_kundeRepository.GetAsync(id)).Returns(kunde);
            //Act
            var result = _kundeController.Edit(id);
            //Assert
            result.Should ().BeOfType< Task < IActionResult >> ();
        }
    }
}
