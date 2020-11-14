namespace BusinessLogic.Define
{
    using DataAccess.Entities;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    public interface IOrderService
    {
        void Create(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
        Order Get(Expression<Func<Order, bool>> predicated, params Expression<Func<Order, object>>[] includes);
        IQueryable<Order> GetAll(params Expression<Func<Order, object>>[] includes);
    }
}
