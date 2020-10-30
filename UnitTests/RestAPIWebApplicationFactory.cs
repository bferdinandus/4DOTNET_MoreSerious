using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Repository.InMemory;
using Repository.Interfaces;
using RestService;

namespace UnitTests
{
    public class RestAPIWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IPersonRepository, RealPersonRepository>();

                
            });            

            base.ConfigureWebHost(builder);
        }
    }
}
