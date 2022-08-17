using Microsoft.Extensions.DependencyInjection;
using SEDC.WebApi.Notes.DataAccess;
using SEDC.WebApi.Notes.DataAccess.Repositories;
using SEDC.WebApi.Notes.DataModels.Models;

namespace SEDC.WebApi.Notes.DependecyInjection
{
    public static class DataAccessExtension
    {
        public static IServiceCollection RegisterDataDependecies(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Note>, NoteRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();

            return services;
        }
    }
}
