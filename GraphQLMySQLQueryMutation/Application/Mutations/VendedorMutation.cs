using GraphQL;
using GraphQL.Types;
using GraphQLMySQLQueryMutation.Domain.Vendedores.DomainModels;
using GraphQLMySQLQueryMutation.Domain.Vendedores.GraphQLModels;
using GraphQLMySQLQueryMutation.Infrastructure.DBContexts;

namespace GraphQLMySQLQueryMutation.Application.Mutuations;

public class VendedorMutation : ObjectGraphType<object>
{
    public VendedorMutation(AppDbContext dbContext)
    {
        // Añadir un Nuevo Vendedor.
        Field<ListGraphType<VendedorType>>("addVendedor")
            .Description("Añade un nuevo Vendedor.")
            .Arguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "nombre" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "movil" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }
            )
            .Resolve(
                context =>
                    {
                        var vendr = new Vendedor()
                        {
                            Id = 0,
                            Nombre = context.GetArgument<string>("nombre"),
                            Movil = context.GetArgument<string>("movil"),
                            Email = context.GetArgument<string>("email")
                        };
                        var Vends = new List<Vendedor>();
                        Vends.Add(vendr);
                        var newVendedor = dbContext.Vendedores.Add(vendr);
                        dbContext.SaveChanges();
                        return Vends;
                    }
            );

        // Eliminar un Vendedor Existente.
        Field<ListGraphType<VendedorType>>("deleteVendedor")
            .Description("Eliminar un nuevo Vendedor.")
            .Arguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            )
            .Resolve(
                context =>
                {
                    var Vends = new List<Vendedor>();
                    try
                    {                        
                        var id = context.GetArgument<int>("id");
                        var qryVend = dbContext.Vendedores.Find(id);
                        Vends.Add(qryVend!);
                        var outVend = dbContext.Vendedores.Remove(qryVend!);
                        dbContext.SaveChanges();
                        return Vends;
                    }
                    catch
                    {
                        return Vends;
                    }
                }
            );

        // Actualizar un Vendedor Existente. 
        Field<ListGraphType<VendedorType>>("updateVendedor")
            .Description("Modificar un nuevo Vendedor.")
            .Arguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "nombre" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "movil" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }
            )
            .Resolve(
                context =>
                {
                    var Vends = new List<Vendedor>();
                    try
                    {
                        var vendr = new Vendedor()
                        {
                            Id = context.GetArgument<int>("id"),
                            Nombre = context.GetArgument<string>("nombre"),
                            Movil = context.GetArgument<string>("movil"),
                            Email = context.GetArgument<string>("email")
                        };
                        Vends.Add(vendr);
                        var outVend = dbContext.Vendedores.Update(vendr);
                        dbContext.SaveChanges();
                        return Vends;
                    }
                    catch
                    {
                        return Vends;
                    }
                }
            );

    }
}