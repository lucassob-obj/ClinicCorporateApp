using ClinicCorporateApp.API.Controllers;
using ClinicCorporateApp.Core.Shared.ModelViews;
using ClinicCorporateApp.Manager.Interfaces.Managers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ClinicCorporateApp.Tests.Controllers
{
    public class ClientesControllerTest
    {
        private readonly IClienteManager manager;
        private readonly ILogger<ClientesController> logger;
        private readonly ClientesController controller;
        public ClientesControllerTest()
        {
            manager = Substitute.For<IClienteManager>();
            logger = Substitute.For<ILogger<ClientesController>>();
            controller = new ClientesController(manager, logger);
        }

        [Fact]
        public async Task GetOk()
        {
            manager.GetClientesAsync().Returns(new List<ClienteView> { new ClienteView { Nome = "Lucas N Sobrinho" } });
            var resultado = (ObjectResult) await controller.Get();
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
