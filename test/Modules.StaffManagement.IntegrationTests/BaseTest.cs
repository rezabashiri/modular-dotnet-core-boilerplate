using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.EmployeeManagement.Extensions;
using Share.Test.Extensions;
using Shared.Test.Extensions;

namespace Modules.EmployeeManagement.IntegrationTests
{
    public class BaseTest
    {
        protected IServiceProvider ServicieProvider { get; }

        public virtual IServiceProvider MakeServiceProvider(IServiceCollection services)
        {
            var configuration = BuildConfiguration();
             services.AddSingleton( configuration);
            services.AddSharedCoreServicesForTestAssemblies(configuration);
            services.AddsSharedInfrastructureForTestAssemblies(configuration);
            services.AddEmployeeManagementModule(configuration);

            return services.BuildServiceProvider();
        }
        public BaseTest()
        {
            ServicieProvider = MakeServiceProvider(new ServiceCollection());
        }

        private IConfiguration BuildConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.GetFullPath("../../../../../src/server/API/appsettings.json"))
                .AddInMemoryCollection(new List<KeyValuePair<string, string>>() // Override for test environment
                {
                    new KeyValuePair<string, string>("PersistenceSettings:UseMsSql","false"),
                    new KeyValuePair<string, string>("PersistenceSettings:UseInMemory","true")
                });
            
            return configuration.Build();
        }
    }
}