namespace Order.Api.Repositories
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        void Save();
    }
}
