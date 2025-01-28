
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OnlineAuctionAPI.Data;
using OnlineAuctionAPI.Models;
namespace OnlineAuctionAPI.Controllers
{
public static class ProductEndpoints
{

        private static readonly ProductRepository productRepository = new ProductRepository();
        public static void MapProductEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Product").WithTags(nameof(Product)); ;
        group.MapGet("/", () =>
        {
            return productRepository.GetAllproducts();
        })
        .WithName("GetAllProducts")
        .Produces<Product[]>(StatusCodes.Status200OK);

        group.MapGet("/{id}", (String id) =>
        {
            return productRepository.GetById(id);
        })
        .WithName("GetProductById")
        .Produces<Product>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", (Product input) =>
        {
            productRepository.Update(input);
        })
        .WithName("UpdateProduct")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);


        group.MapPost("/", (Product model) =>
        {
            productRepository.Create(model);
        })
        .WithName("CreateProduct")
        .Produces<Product>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", (String id) =>
        {
            productRepository.Delete(id);
        })
        .WithName("DeleteProduct")
        .Produces<Product>(StatusCodes.Status200OK);
    }
}}
