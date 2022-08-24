using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.WebApi.Notes.DataAccess;
using SEDC.WebApi.Notes.DataAccess.Repositories;
using SEDC.WebApi.Notes.DataModels.Models;

namespace SEDC.WebApi.Notes.DependecyInjection
{
    public static class DataAccessExtension
    {
        public static IServiceCollection RegisterDataDependecies(this IServiceCollection services, string connectionString = null)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                services.AddDbContext<NotesDbContext>(options =>
                options.UseSqlServer(connectionString));
            }

            //services.AddTransient<IRepository<Note>, NoteRepository>();
            //services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Note>, NoteEFRepository>();
            services.AddTransient<IRepository<User>, UserEFRepository>();

            return services;
        }
    }
}
