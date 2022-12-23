using APIGateway.URIs;

namespace APIGateway.Clients;

public class PizzaClient : IPizzaClient
{
    private readonly OrderUri _orderUri;
    public PizzaClient(OrderUri orderUri)
    {
        _orderUri = orderUri;
    }
    public Task<HttpResponseMessage> CreatePizza(string name, decimal price)
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> DeletePizza(int id)
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> EditPizza(int id, string name, decimal price)
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> GetAllPizzas()
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> GetPizzaById(int id)
    {
        throw new NotImplementedException();
    }
}
