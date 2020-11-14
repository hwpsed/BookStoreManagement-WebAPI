using BusinessLogic.Define;
using BusinessLogic.Implement;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreUI.ViewModels
{
    public class _ModelMapping
    {
        #region Book

        public Book ConverToModel(BookInsertVM model)
        => new Book
        {
            Author = model.Author,
            Title = model.Title,
            Price = model.Price,
            Image = model.Image,
            Stock = model.Stock,
            CategoryId = model.CategoryId,
            //CategoryId = ConvertToModel(model.Category).Id,
            ImportDate = System.DateTime.Now.ToString("yyyy-MM-dd"),
            Status = BookStatus.Active
        };

        public BookVM ConvertToViewModel(Book model)
        => new BookVM
        {
            Id = model.Id,
            Author = model.Author,
            Title = model.Title,
            Price = model.Price,
            Image = model.Image,
            Stock = model.Stock,
            ImportDate = model.ImportDate,
            Status = model.Status == BookStatus.Active ? "Active" : "Deactive",
            Category = ConvertToViewModelOfBook(model.Category)
        };

        public ICollection<BookVM> ConvertToViewModels(ICollection<Book> models)
            => models.Select(m => ConvertToViewModel(m)).ToList();

        #endregion

        #region Category

        public Category ConvertToModel(CategoryVM model)
            => new Category
            {
                Id = model.Id,
                Name = model.Name
            };
        public CategoryVM ConvertToViewModelOfBook(Category model)
        => new CategoryVM
        {
            Id = model.Id,
            Name = model.Name
        };
        public CategoryVM ConvertToViewModel(Category model)
        => new CategoryVM
        {
            Id = model.Id,
            Name = model.Name,
            Books = ConvertToViewModels(model.Books).ToList()
        };
        public ICollection<CategoryVM> ConvertToViewModels(ICollection<Category> models)
            => models.Select(m => ConvertToViewModelOfBook(m)).ToList();
        #endregion


        #region Account
        public AccountVM ConvertToViewModel(Account model)
        => new AccountVM
        {
            Username = model.Username,
            Name = model.Name,
            RoleId = model.RoleId,
            Role = ConvertToViewModelOfAccount(model.Role)
        };
        public ICollection<AccountVM> ConvertToViewModels(ICollection<Account> models)
            => models.Select(m => ConvertToViewModel(m)).ToList();
        #endregion


        #region Order
        public OrderVM ConvertToViewModel(Order model)
        => new OrderVM
        {
            Id = model.Id,
            CreateDate = model.CreateDate,
            TotalAmount = model.TotalAmount,
            Username = model.Username,
            PaymentId = model.PaymentId,
            Payment = ConvertToViewModel(model.Payment),
            Account = ConvertToViewModel(model.Account),
            OrderDetails = ConvertToViewModels(model.OrderDetails).ToList()

        };
        public ICollection<OrderVM> ConvertToViewModels(ICollection<Order> models)
            => models.Select(m => ConvertToViewModel(m)).ToList();
        #endregion


        #region OrderDetail
        public OrderDetailVM ConvertToViewModel(OrderDetail model)
        => new OrderDetailVM
        {
            Id = model.Id,
            OrderId = model.OrderId,
            Quantity = model.Quantity,
            Book = ConvertToViewModel(model.Book),
        };
        public ICollection<OrderDetailVM> ConvertToViewModels(ICollection<OrderDetail> models)
            => models.Select(m => ConvertToViewModel(m)).ToList();
        #endregion

        #region Payment
        public PaymentVM ConvertToViewModel(Payment model)
        => new PaymentVM
        {
            Id = model.Id,
            Name = model.Name,
        };
        public PaymentVM ConvertToViewModelOfOrder(Payment model)
        => new PaymentVM
        {
            Id = model.Id,
            Name = model.Name
        };
        public ICollection<PaymentVM> ConvertToViewModels(ICollection<Payment> models)
            => models.Select(m => ConvertToViewModelOfOrder(m)).ToList();
        #endregion


        #region Role
        public RoleVM ConvertToViewModel(Role model)
        => new RoleVM
        {
            Id = model.Id,
            Name = model.Name,
            Accounts = ConvertToViewModels(model.Accounts).ToList()
        };
        public RoleVM ConvertToViewModelOfAccount(Role model)
        => new RoleVM
        {
            Id = model.Id,
            Name = model.Name
        };

        public ICollection<RoleVM> ConvertToViewModels(ICollection<Role> models)
            => models.Select(m => ConvertToViewModelOfAccount(m)).ToList();
        #endregion
    }
}
