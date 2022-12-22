using APIGateway.Clients;

namespace APIGateway.Services.Pizza
{
    public class DeletePizzaService
    {

        private readonly IPizzaClient _pizzaClient;

        public DeletePizzaService(IPizzaClient pizzaClient)
        {
            _pizzaClient = pizzaClient;
        }

        public async Task<IResult> HandleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
