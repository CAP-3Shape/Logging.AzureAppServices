using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.AzureAppServices.Sample
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Bind options classes to configuration sections.
            services.AddOptions<MyOptions>()
                .Bind(Configuration.GetSection(MyOptions.Name))
                .ValidateDataAnnotations()
                .ValidateOnStart();
        }

        public class MyOptions
        {
            public const string Name = "MyOptions";
            public string Foo { get; set; } = string.Empty;
        }
    }
}
