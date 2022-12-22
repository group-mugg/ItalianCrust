namespace APIGateway.Clients
{
    public interface IOrderClient
    {
        public Task<HttpResponseMessage> GetAllOrders();
        public Task<HttpResponseMessage> GetOrderById(int id);
        public Task<HttpResponseMessage> EditOrder(string name, Dictionary<int,int> pizzaIdQuantity);
        public Task<HttpResponseMessage> CreateOrder(string name, Dictionary<int,int> pizzaIdQuantity);
        public Task<HttpResponseMessage> DeleteOrder(int id);
    }
}
