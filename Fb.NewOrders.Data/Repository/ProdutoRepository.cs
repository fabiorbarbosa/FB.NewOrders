using FB.NewOrders.Data.Context;
using FB.NewOrders.Domain.Interfaces;
using FB.NewOrders.Domain.Entities;

namespace FB.NewOrders.Data.Repository
{
    public class ProdutoRepository : Repository<Product>, IProdutoRepository
    {
        public ProdutoRepository(NewOrdersDbContext context) : base(context)
        {
            
        }
    }
}