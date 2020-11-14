using BookStoreUI.ViewModels;
using BusinessLogic.Define;
using BusinessLogic.Implement;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : _BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("account")]
        public IActionResult GetAccountInfo([FromBody] string username)
        {
            try
            {
                var account = _accountService.Get(_ => _.Username.Equals(username));
                var result = ModelMapper.ConvertToViewModel(account);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
