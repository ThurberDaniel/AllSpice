using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Recipe> GetAll()
        {
            return _repo.GetAll();
        }

        internal Recipe GetById(int id)
        {
            Recipe recipe = _repo.GetById(id);
            if (recipe == null)
            {
                throw new Exception("Invalid Recipe Id");
            }
            return recipe;
        }

        internal IEnumerable<Recipe> GetByCreatorId(string id)
        {
            return _repo.GetByCreatorId(id);
        }



        internal Recipe Create(Recipe newRecipe)
        {
            return _repo.Create(newRecipe);
        }

        internal void Delete(int id, string creatorId)
        {
            Recipe recipe = GetById(id);
            if (recipe.CreatorId != creatorId)
            {
                throw new Exception("You cannot delete another users Recipe");
            }
            if (!_repo.Delete(id))
            {
                throw new Exception("Something has gone terribly wrong");
            };
        }
    }
}