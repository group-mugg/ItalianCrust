using APIGateway.Clients;

namespace APIGateway.Services.Order
{
    public class GetOrderByIdService
    {
        private readonly IOrderClient _orderClient;

        public GetOrderByIdService(IOrderClient orderClient)
        {
            _orderClient = orderClient;
        }

        public async Task<IResult> HandleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
