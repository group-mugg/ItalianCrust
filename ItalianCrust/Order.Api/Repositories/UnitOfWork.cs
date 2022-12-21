namespace Order.Api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ModelDbContext _modelDbContext;

        private IOrderRepository? _orderRepository;
        public IOrderRepository OrderRepository => _orderRepository ?? (_orderRepository = new OrderRepository(_modelDbContext));

        public UnitOfWork(ModelDbContext modelDbContext)
        {
            _modelDbContext = modelDbContext;
        }

        public void Save()
        {
            _modelDbContext.SaveChanges();
        }
    }
}
