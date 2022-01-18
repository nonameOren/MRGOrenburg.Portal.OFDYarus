using Convey;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MRG.OFDYarus.Api.Services;
using MRG.OFDYarus.Api.Services.Clients;
using MRG.OFDYarus.Application.Services;

namespace MRG.OFDYarus.Api
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services.AddSingleton<IOFDClient, CustomClient>();
            builder.Services.AddTransient<IOfdService, OfdService>();
            return builder;
        }
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
