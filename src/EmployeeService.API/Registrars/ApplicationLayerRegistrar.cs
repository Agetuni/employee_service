using VisaService.Infrastructure.HttpServices;

namespace EmployeeService.API.Registrars
{
    public class ApplicationLayerRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSession(options =>
            {
                options.IOTimeout = TimeSpan.FromMinutes(10);
            });
            builder.WebHost.ConfigureKestrel(k =>
            {
                k.Limits.MaxRequestHeadersTotalSize = 64 * 1024;
                k.Limits.MaxRequestBufferSize = 64 * 1024;
            });
            builder.Services.AddMediatR(typeof(CreatePosition));
            builder.Services.AddAutoMapper(typeof(Program), typeof(CreatePosition));

            // application layer DI  
            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddHttpClient<IIdentityService, IdentityService>();
            builder.Services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
