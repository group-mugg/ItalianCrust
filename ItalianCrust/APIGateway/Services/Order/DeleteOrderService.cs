using APIGateway.Clients;

namespace APIGateway.Services.Order
{
    public class DeleteOrderService
    {

        private readonly IOrderClient _orderClient;

        public DeleteOrderService(IOrderClient orderClient)
        {
            _orderClient = orderClient;
        }

        public async Task<IResult> HandleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
