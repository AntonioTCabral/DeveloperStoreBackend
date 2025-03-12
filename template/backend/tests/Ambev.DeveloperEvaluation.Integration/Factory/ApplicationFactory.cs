using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NSubstitute;

namespace Ambev.DeveloperEvaluation.Integration.Factory;

public class ApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<IMediator>();
            var mediatorSubstitute = Substitute.For<IMediator>();
            services.AddSingleton(mediatorSubstitute);
        });
    }
}