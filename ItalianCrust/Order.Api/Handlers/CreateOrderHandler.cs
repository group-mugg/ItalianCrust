﻿using Order.Api.Repositories;
using Order.Api.Requests;

namespace Order.Api.Handlers;

public static class CreateOrderHandler
{
    public static async Task<IResult> HandleAsync(IOrderRepository repo, CreateOrderRequest request)
    {
        throw new NotImplementedException();
    }
}
