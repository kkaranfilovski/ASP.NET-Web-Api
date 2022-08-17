using Microsoft.Extensions.DependencyInjection;
using SEDC.WebApi.Notes.Services;
using SEDC.WebApi.Notes.Services.Interfaces;

namespace SEDC.WebApi.Notes.DependecyInjection
{
    public static class ServicesExtensions
    {
        public static IServiceCollection RegisterServicesDependecies(this IServiceCollection services)
        {
            services.AddTransient<INoteService, NoteService>();

            return services;
        }
    }
}
