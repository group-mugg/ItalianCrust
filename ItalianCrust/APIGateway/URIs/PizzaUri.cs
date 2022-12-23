namespace APIGateway.URIs;

public class PizzaUri
{
    private readonly string _host;

    public PizzaUri(string host)
    {
        _host = host;
    }

    public string CreatePizza() => $"{_host}/pizzas";
    public string GetAllPizzas() => $"{_host}/pizzas";
    public string GetPizzaById(int id) => $"{_host}/pizzas/{id}";
    public string EditPizza() => $"{_host}/pizzas";
    public string DeletePizza(int id) => $"{_host}/pizzas/{id}";
}
