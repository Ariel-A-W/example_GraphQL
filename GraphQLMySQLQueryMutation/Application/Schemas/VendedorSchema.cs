using GraphQL.Types;
using GraphQLMySQLQueryMutation.Application.Mutuations;
using GraphQLMySQLQueryMutation.Application.Queries;

namespace GraphQLMySQLQueryMutation.Application.Schemas;

public class VendedorSchema : Schema
{
    public VendedorSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<VendedorQuery>();
        Mutation = serviceProvider.GetRequiredService<VendedorMutation>();
    }
}
