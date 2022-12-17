namespace Pizza.Api.Repositories
{
    public interface IPizzaRepository
    {
        Task<bool> CreatePizza(Models.Pizza pizza);
        Task<IEnumerable<Models.Pizza>> GetAllPizzas();
        Task<Models.Pizza?> GetPizzaById(int id);
        Task<bool> EditPizza(Models.Pizza pizza);
        Task<bool> DeletePizza(int id);
    }
}