using Microsoft.EntityFrameworkCore;

namespace HealthyPaws.Dal;

public static class HealthyPawsDbContextExtensions
{
    public static void AddHealthyPawsDb(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<HealthyPawsDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("HealthyPaws"));
        });
    }

    public static void AddInMemoryHealthyPawsDb(this IServiceCollection services)
    {
        services.AddDbContext<HealthyPawsDbContext>(options =>
        {
            options.UseInMemoryDatabase("HealthyPaws");
        });
    }
    public static void EnsureHealthyPawsDbIsCreated(this IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetService<HealthyPawsDbContext>()!;
        db.Database.EnsureCreated();
        db.Dispose();
    }
}