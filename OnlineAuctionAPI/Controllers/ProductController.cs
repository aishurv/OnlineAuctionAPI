using DB;
using Microsoft.AspNetCore.Mvc;
using OnlineAuctionAPI.Models;
namespace OnlineAuctionAPI.Controllers
{
public static class ProductEndpoints
{
	public static void MapProductEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Product");

        group.MapGet("/", () =>
        {
            return DBConnection.Products;
        })
        .WithName("GetAllProducts")
        .Produces<Product[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", (String id) =>
        {
            var product = DBConnection.Products.FirstOrDefault(u => u._id == id);
            //if (product == null)
            //    generateNo
            return product;
        })
        .WithName("GetProductById")
        .Produces<Product>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", (String id, Product input) =>
        {
            var product = DBConnection.Products.FirstOrDefault(p=>p._id == id);
            if (product != null)
            {
                //DBConnection.Products.Save(product);
                return Results.NoContent();
            }
            else
            {
                return Results.NotFound(id);
            }

        })
        .WithName("UpdateProduct")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);


        group.MapPost("/", (Product model) =>
        {
            DBConnection.AddProduct(model);
            return Results.Created();
            //return Results.Created($"/api/Products/{model._id}", model);
        })
        .WithName("CreateProduct")
        .Produces<Product>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", (String id) =>
        {
            //return Results.Ok(new Product { ID = id });
        })
        .WithName("DeleteProduct")
        .Produces<Product>(StatusCodes.Status200OK);
    }
}}
