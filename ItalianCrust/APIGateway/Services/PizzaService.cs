using APIGateway.URIs;

namespace APIGateway.Services;

public class PizzaService
{
    private readonly HttpClient _httpClient;
    private readonly PizzaUri _pizzaUri;

    public PizzaService(IHttpClientFactory httpClientFactory, PizzaUri pizzaUri)
    {
        _httpClient = httpClientFactory.CreateClient();
        _pizzaUri = pizzaUri;
    }

    public async Task<string> GetAllPizzas()
    {
        var pizzas = await _httpClient.GetStringAsync(_pizzaUri.GetAllPizzas());
        return pizzas;
    }

    public async Task<string> GetPizzaById(int id)
    {
        var pizza = await _httpClient.GetStringAsync(_pizzaUri.GetPizzaById(id));
        return pizza;
    }
}
