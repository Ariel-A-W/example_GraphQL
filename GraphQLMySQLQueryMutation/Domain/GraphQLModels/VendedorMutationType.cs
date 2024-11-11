using GraphQL.Types;

namespace GraphQLMySQLQueryMutation.Domain.GraphQLModels;

public class VendedorMutationType : InputObjectGraphType
{
    public VendedorMutationType()
    {
        Name = "VendedorInput";
        Field<NonNullGraphType<StringGraphType>>("nombre");
        Field<NonNullGraphType<StringGraphType>>("movil");
        Field<NonNullGraphType<StringGraphType>>("email");
    }
}
