

namespace EmployeeService.API.Registrars
{
    public class RepositoryRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepositoryBase<Position>), typeof(RepositoryBase<Position>));
        }
    }
}
