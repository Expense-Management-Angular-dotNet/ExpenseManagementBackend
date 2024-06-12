using ExpenseManagement.Data;

namespace ExpenseManagement.Extensions
{
    public static class ServiceExtensions
    {
      
        public static void ConfigureUnitOfWork(this IServiceCollection services) =>
                    services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
