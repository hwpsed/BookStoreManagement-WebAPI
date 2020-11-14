namespace BusinessLogic.Define
{
    using DataAccess.Entities;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    public interface ICategoryService
    {
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category Get(Expression<Func<Category, bool>> predicated, params Expression<Func<Category, object>>[] includes);
        IQueryable<Category> GetAll(params Expression<Func<Category, object>>[] includes);
    }
}
