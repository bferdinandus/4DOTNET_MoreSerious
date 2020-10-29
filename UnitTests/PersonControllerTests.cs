using Entities;
using Fakes;
using Microsoft.AspNetCore.Mvc.Testing;
using RestService;
using System;
using System.Collections.Generic;
using Xunit;
using System.Text.Json;

namespace UnitTests
{
    public class PersonControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private WebApplicationFactory<Startup> _factory;

        public PersonControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void TestPersonGet()
        {
            System.Net.Http.HttpClient client = _factory.CreateClient();

            var result = await client.GetAsync("/person");
                        
            string resultString = await result.Content.ReadAsStringAsync();
            List<Person> personList = JsonSerializer.Deserialize<List<Person>>(resultString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.Equal(200, (int)result.StatusCode);

        }
    }
}
