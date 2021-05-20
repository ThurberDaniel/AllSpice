using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _service;
        private readonly AccountsService _acctService;

        public IngredientsController(IngredientsService service, AccountsService acctsService)
        {
            _service = service;
            _acctService = acctsService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Ingredient>> GetAll()
        {
            try
            {
                IEnumerable<Ingredient> ingredients = _service.GetAll();
                return Ok(ingredients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Ingredient> GetById(int id)
        {
            try
            {
                Ingredient found = _service.GetById(id);
                return Ok(found);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient newIngredient)
        {
            try
            {
                // TODO[epic=Auth] Get the user info to set the creatorID
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                // safety to make sure an account exists for that user before CREATE-ing stuff.
                _acctService.GetOrCreateAccount(userInfo);
                // newIngredient.CreatorId = userInfo.Id;

                Ingredient ingredient = _service.Create(newIngredient);
                return Ok(ingredient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Ingredient>> Delete(int id)
        {
            try
            {
                // TODO[epic=Auth] Get the user info to set the creatorID
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                // safety to make sure an account exists for that user before CREATE-ing stuff.
                _service.Delete(id, userInfo.Id);
                return Ok("Delorted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}