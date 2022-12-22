namespace APIGateway.Clients
{
    public interface IPizzaClient
    {
        public Task<HttpResponseMessage> GetAllPizzas();
        public Task<HttpResponseMessage> GetPizzaById(int id);
        public Task<HttpResponseMessage> EditPizza(int id, string name, decimal price);
        public Task<HttpResponseMessage> CreatePizza(string name, decimal price);
        public Task<HttpResponseMessage> DeletePizza(int id);

    }
}
