using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TalkMind.Api.Test.Infrastructure;

[TestClass]
public class DependencyContainerTests
{
    [TestMethod]
    public void Validate_DI_Container()
    {
        var builder = WebApplication.CreateBuilder();
        var services = builder.Services;
        var configuration = Mock.Of<IConfiguration>();

        Program.ConfigureServices(services, configuration);

        var provider = services.BuildServiceProvider(
            new ServiceProviderOptions { ValidateOnBuild = true }
        );

        Assert.IsNotNull(provider);
    }
}