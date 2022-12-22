using APIGateway.Clients;

namespace APIGateway.Services.Pizza
{
    public class EditPizzaService
    {

        private readonly IPizzaClient _pizzaClient;

        public EditPizzaService(IPizzaClient pizzaClient)
        {
            _pizzaClient = pizzaClient;
        }

        public async Task<IResult> HandleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
