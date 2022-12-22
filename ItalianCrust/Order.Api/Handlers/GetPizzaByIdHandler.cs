using Microsoft.EntityFrameworkCore;
using Order.Api.DTOs;
using Order.Api.Models;
using Order.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Order.Api.Handlers;

public static class GetPizzaByIdHandler
{
    private static readonly ModelDbContext? _dBContext;

    public static async Task<IResult> HandleAsync(IPizzaRepository repo, int id)
    {
        throw new NotImplementedException();
    }
}
