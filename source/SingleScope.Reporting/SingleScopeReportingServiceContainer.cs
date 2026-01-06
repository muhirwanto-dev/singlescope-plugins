using Microsoft.Extensions.DependencyInjection;

namespace SingleScope.Reporting
{
    public class SingleScopeReportingServiceContainer
    {
        public IServiceCollection Services { get; }

        public SingleScopeReportingServiceContainer(IServiceCollection services)
        {
            Services = services;
        }
    }
}
