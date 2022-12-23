﻿using APIGateway.Clients;

namespace APIGateway.Services.Pizza
{
    public class CreatePizzaService
    {
        private readonly IPizzaClient _pizzaClient;

        public CreatePizzaService(IPizzaClient pizzaClient)
        {
            _pizzaClient = pizzaClient;
        }

        public async Task<IResult> HandleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
