﻿namespace GraphQLMySQLQueryMutation.Domain.Vendedores.DomainModels;

public class Vendedor
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Movil {  get; set; }
    public string? Email { get; set; }
}
