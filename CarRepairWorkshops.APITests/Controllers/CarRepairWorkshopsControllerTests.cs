using Xunit;
using CarRepairWorkshops.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization.Policy;
using CarRepairWorkshops.APITests;

namespace CarRepairWorkshops.API.Controllers.Tests
{
    public class CarRepairWorkshopsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;

        public CarRepairWorkshopsControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder=>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                });
                
            });

        }

        [Fact()]
        public async Task GetAll_ForValidRequest_Returns200Ok()
        {

            
            //arrange
            var client = _factory.CreateClient();

            //act
            var result = await client.GetAsync("/api/carRepairWorkshops?pageNumber=1&pageSize=5");

            //assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        }

        [Fact()]
        public async Task GetAll_ForBadRequest_Returns400()
        {
            //arrange
            var client = _factory.CreateClient();

            //act
            var result = await client.GetAsync("/api/carRepairWorkshops");

            //assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

        }

        [Fact()]
        public void GetAllWorkshopsAsyncTest()
        {

        }

        [Fact()]
        public void CreateWorkshopTest()
        {

        }

        [Fact()]
        public void DeleteWorkshopTest()
        {

        }
    }
}