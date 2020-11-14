
using BookStoreUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreUI.Controllers
{
    public class _BaseController : ControllerBase
    {
        private _ModelMapping _modelMapper;
        public _ModelMapping ModelMapper => _modelMapper ?? (_modelMapper = new _ModelMapping());
    }
}