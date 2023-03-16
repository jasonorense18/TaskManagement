using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Contract.Authentication;
using TaskManagement.Infrastructure.Persistence.Context;

namespace TaskManagement.Api.Test.Common;

public abstract class IntegrationTest
{
    protected readonly HttpClient TestClient;
    protected static AuthenticationResponse AuthenticationResponse;

    protected IntegrationTest()
    {
        // This will overwrite the existing db context and create an inmemory db
        var webAppFactory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<TaskDbContext>));

                    services.Remove(descriptor);

                    services.AddDbContext<TaskDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestDb");
                    });

                    //services.AddTransient<IAuthenticationSchemeProvider, MockSchemeProvider>();
                    //services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                });

            });

        TestClient = webAppFactory.CreateClient();

    }
}
