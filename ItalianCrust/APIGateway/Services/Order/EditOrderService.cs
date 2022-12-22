using APIGateway.Clients;

namespace APIGateway.Services.Order
{
    public class EditOrderService
    {
        private readonly IOrderClient _orderClient;

        public EditOrderService(IOrderClient orderClient)
        {
            _orderClient = orderClient;
        }

        public async Task<IResult> HandleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
