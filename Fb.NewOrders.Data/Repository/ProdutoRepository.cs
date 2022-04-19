using FB.NewOrders.Data.Context;
using FB.NewOrders.Domain.Interfaces;
using FB.NewOrders.Domain.Entity;

namespace FB.NewOrders.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(NewOrdersDbContext context) : base(context)
        {
            
        }
    }
}