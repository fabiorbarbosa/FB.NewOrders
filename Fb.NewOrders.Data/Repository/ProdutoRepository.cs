using FB.NewOrders.Business.Interfaces;
using FB.NewOrders.Business.Models;
using FB.NewOrders.Data.Context;

namespace FB.NewOrders.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(NewOrdersDbContext context) : base(context)
        {
            
        }
    }
}