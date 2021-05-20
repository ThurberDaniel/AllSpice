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
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _service;
        private readonly AccountsService _acctService;

        public RecipesController(RecipesService service, AccountsService acctsService)
        {
            _service = service;
            _acctService = acctsService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetAll()
        {
            try
            {
                IEnumerable<Recipe> recipes = _service.GetAll();
                return Ok(recipes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Recipe> GetById(int id)
        {
            try
            {
                Recipe found = _service.GetById(id);
                return Ok(found);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Recipe>> Create([FromBody] Recipe newRecipe)
        {
            try
            {
                // TODO[epic=Auth] Get the user info to set the creatorID
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                // safety to make sure an account exists for that user before CREATE-ing stuff.
                _acctService.GetOrCreateAccount(userInfo);
                newRecipe.CreatorId = userInfo.Id;

                Recipe recipe = _service.Create(newRecipe);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Recipe>> Delete(int id)
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