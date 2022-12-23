namespace APIGateway.URIs;

public class OrderUri
{
    private readonly string _host;

    public OrderUri(string host)
    {
        _host = host;
    }

    //ORDERS
    public string CreateOrder() => $"{_host}/orders";
    public string GetAllOrders() => $"{_host}/orders";
    public string GetOrderById(int id) => $"{_host}/orders/{id}";
    public string DeleteOrder(int id) => $"{_host}/orders/{id}";

    //PIZZAS
    public string CreatePizza() => $"{_host}/pizzas";
    public string GetAllPizzas() => $"{_host}/pizzas";
    public string GetPizzaById(int id) => $"{_host}/pizzas/{id}";
    public string EditPizza() => $"{_host}/pizzas";
    public string DeletePizza(int id) => $"{_host}/pizzas/{id}";
}
