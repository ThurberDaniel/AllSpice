using System;
using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace AllSpice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // TODO[epic=Auth] Adds authguard to all routes on the whole controller
    [Authorize]
    public class AccountController : ControllerBase
    {


        private readonly AccountsService _service;

        public AccountController(AccountsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                // TODO[epic=Auth] Replaces req.userinfo
                // IF YOU EVER NEED THE ACTIVE USERS INFO THIS IS HOW YOU DO IT (FROM AUTH0)
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Account currentUser = _service.GetOrCreateAccount(userInfo);
                return Ok(currentUser);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }


        }
    }
}