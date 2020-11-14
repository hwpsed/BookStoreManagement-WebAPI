namespace BusinessLogic.Define

{
    using DataAccess.Entities;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    public interface IPaymentService
    {
        void Create(Payment entity);
        void Update(Payment entity);
        void Delete(Payment entity);
        Payment Get(Expression<Func<Payment, bool>> predicated, params Expression<Func<Payment, object>>[] includes);
        IQueryable<Payment> GetAll(params Expression<Func<Payment, object>>[] includes);
    }
}
