using APIGateway.Clients;

namespace APIGateway.Services.Pizza
{
    public class GetPizzaByIdService
    {
        private readonly IPizzaClient _pizzaClient;

        public GetPizzaByIdService(IPizzaClient pizzaClient)
        {
            _pizzaClient = pizzaClient;
        }

        public async Task<IResult> HandleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
