using Entities;
using Fakes;
using Microsoft.AspNetCore.Mvc.Testing;
using RestService;
using System;
using System.Collections.Generic;
using Xunit;
using System.Text.Json;
using Repository.InMemory;
using RestService.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class PersonControllerTests : IClassFixture<RestAPIWebApplicationFactory>
    {
        private RestAPIWebApplicationFactory _factory;

        public PersonControllerTests(RestAPIWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void IntegratieTestPersonGet()
        {
            // Dit is een Integratie Test
            System.Net.Http.HttpClient client = _factory.CreateClient();

            var result = await client.GetAsync("/person?take=2&skip=1");

            string resultString = await result.Content.ReadAsStringAsync();
            

            Assert.Equal(200, (int)result.StatusCode);
            // Headers testen en zo... ?
            // Bv. sanitizer loop hier WEL mee...
        }

        [Fact]
        public async void UnitTestPersonGet()
        {
            // Dit is een Unit Test
            RealPersonRepository repo = new RealPersonRepository();
            PersonController ctrl = new PersonController(repo);
            
            var result = ctrl.Get(take:2, skip:1) as OkObjectResult;
            var personList = result?.Value as List<Person>;

            // Bv. sanitizer loop hier NIET mee...

            Assert.Equal(2, personList.Count);
            Assert.Collection(personList,
                item => Assert.Equal("Julie", item.FirstName),
                item => Assert.Equal("Anton", item.FirstName));
        }


    }
}
