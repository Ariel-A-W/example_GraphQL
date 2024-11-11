using GraphQL.Types;
using GraphQLMySQLQueryMutation.Domain.Vendedores.DomainModels;

namespace GraphQLMySQLQueryMutation.Domain.Vendedores.GraphQLModels;

public class VendedorType : ObjectGraphType<Vendedor>
{
    public VendedorType()
    {
        Field(x => x.Id).Description("ID del Vendedor");
        Field(x => x.Nombre).Description("Nombre del Vendedor");
        Field(x => x.Movil).Description("Movil del Vendedor");
        Field(x => x.Email).Description("Email del Vendedor");
    }
}
