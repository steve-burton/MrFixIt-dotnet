using MrFixIt.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrFixIt.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace MrFixIt.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
