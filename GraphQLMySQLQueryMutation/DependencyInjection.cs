using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using GraphQLMySQLQueryMutation.Application.Schemas;
using GraphQLMySQLQueryMutation.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace GraphQLMySQLQueryMutation;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services
    )
    {
        return services;
    }

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Sección para configura MySQL Server.
        var connectionString = configuration.GetConnectionString("LibreriaConnection")
             ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<AppDbContext>(
            options =>
                options.UseMySql(
                    connectionString,
                    new MySqlServerVersion(
                        new Version(8, 0, 21)
                    )
                )
        );

        // Sección para GraphQL. 
        services.AddScoped<ISchema, VendedorSchema>(
            servs =>
            {
                return new VendedorSchema(new SelfActivatingServiceProvider(servs));
            }
        );

        services.AddGraphQL(builder =>
        {
           builder.AddSystemTextJson();
        });
    
        return services;
    }
}
