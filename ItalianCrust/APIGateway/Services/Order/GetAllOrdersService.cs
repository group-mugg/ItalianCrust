using APIGateway.Clients;

namespace APIGateway.Services.Order
{
    public class GetAllOrdersService
    {
        private readonly IOrderClient _orderClient;

        public GetAllOrdersService(IOrderClient orderClient)
        {
            _orderClient = orderClient;
        }

        public async Task<IResult> HandleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
