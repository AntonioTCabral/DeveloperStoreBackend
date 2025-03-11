using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories.Base;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : BaseRepository<Cart>, ICartRepository
{
    public CartRepository(DefaultContext context) : base(context)
    {
    }
}