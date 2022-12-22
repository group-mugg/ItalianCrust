﻿using APIGateway.Clients;

namespace APIGateway.Services.Pizza
{
    public class GetAllPizzasService
    {
        private readonly IPizzaClient _pizzaClient;

        public GetAllPizzasService(IPizzaClient pizzaClient)
        {
            _pizzaClient = pizzaClient;
        }

        public async Task<IResult> HandleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
