using Microsoft.EntityFrameworkCore;
using Order.Api.DTOs;
using Order.Api.Models;
using Order.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Order.Api.Handlers;

public static class GetPizzaByIdHandler
{
    public static async Task<IResult?> HandleAsync(IPizzaRepository repo, int id)
    {
        if (await repo.GetPizzaById(id) == null)
            return Results.NotFound();

        return Results.Ok(await repo.GetPizzaById(id));
    }
}
