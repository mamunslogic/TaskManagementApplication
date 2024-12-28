using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Commands.CreateProject;
using TaskManagement.Application.Commands.CreateTask;
using TaskManagement.Application.Queries.GetTaskByIdQuery;
using TaskManagement.Application.Queries.ProjectQuery;
using TaskManagement.Application.Queries.TaskQuery;
using TaskManagement.Application.Queries.UserQuery;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Persistence.Data;
using TaskManagement.Persistence.Repositories;

namespace TaskManagement.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTaskCommand).Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTaskByIdQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TaskQuery).Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserQuery).Assembly));
            //.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProjectCommand).Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProjectQuery).Assembly));
            // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly));
        }

        public static void AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("TaskManagement.Persistence")));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            //}, ServiceLifetime.Singleton);

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
        }

        public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
