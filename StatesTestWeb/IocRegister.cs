using Microsoft.Extensions.DependencyInjection;
using StatesTest.Data.Repositories;
using StatesTestWeb.Helper;

namespace StatesTestWeb
{
    public static class IocRegister
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ITestResultRepository, TestResultRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStateRepository, StateRepository>();

          
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<QuizBuilder>();
        }
    }
}