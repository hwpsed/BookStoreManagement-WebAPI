using DataAccess.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace BusinessLogic.Define
{
    public interface IBookService
    {
        void Create(Book entity);
        void Update(Book entity);
        void Delete(Book entity);
        Book Get(Expression<Func<Book, bool>> predicated, params Expression<Func<Book, object>>[] includes);
        IQueryable<Book> GetAll(params Expression<Func<Book, object>>[] includes);
    }
}
