namespace BusinessLogic.Define
{
    using DataAccess.Entities;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    public interface IOrderDetailService
    {
        void Create(OrderDetail entity);
        void Update(OrderDetail entity);
        void Delete(OrderDetail entity);
        OrderDetail Get(Expression<Func<OrderDetail, bool>> predicated, params Expression<Func<OrderDetail, object>>[] includes);
        IQueryable<OrderDetail> GetAll(params Expression<Func<OrderDetail, object>>[] includes);
    }
}
