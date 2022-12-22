using APIGateway.Clients;

namespace APIGateway.Services.Order
{
    public class CreateOrderService
    {

        private readonly IOrderClient _orderClient;

        public CreateOrderService(IOrderClient orderClient)
        {
            _orderClient = orderClient;
        }

        public async Task<IResult> HandleAsync()
        {
            throw new NotImplementedException();
        }

    }
}
