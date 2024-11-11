using GraphQL;
using GraphQL.Types;
using GraphQLMySQLQueryMutation.Domain.Vendedores.GraphQLModels;
using GraphQLMySQLQueryMutation.Infrastructure.DBContexts;

namespace GraphQLMySQLQueryMutation.Application.Queries;

public class VendedorQuery : ObjectGraphType
{
    public VendedorQuery(AppDbContext dbContext)
    {
        Field<ListGraphType<VendedorType>>("vendedores")
            .Description("Listado de los vendedores.")
            .Resolve(context => dbContext.Vendedores.ToList());

        Field<VendedorType>("vendedor")
            .Description("Muesta un Vendedor.")
            .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Id" }))
            .Resolve(context =>
            {
                var id = context.GetArgument<int>("Id");
                return dbContext.Vendedores.Find(id);
            });
    }
}
