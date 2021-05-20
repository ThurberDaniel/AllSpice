using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;

        public IngredientsService(IngredientsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Ingredient> GetAll()
        {
            return _repo.GetAll();
        }

        internal Ingredient GetById(int id)
        {
            Ingredient ingredient = _repo.GetById(id);
            if (ingredient == null)
            {
                throw new Exception("Invalid Ingredient Id");
            }
            return ingredient;
        }

        internal IEnumerable<Ingredient> GetByRecipesId(string id)
        {
            return _repo.GetByRecipesId(id);
        }



        internal Ingredient Create(Ingredient newIngredient)
        {
            return _repo.Create(newIngredient);
        }

        internal void Delete(int id, string creatorId)
        {
            Ingredient ingredient = GetById(id);
            // if (ingredient.CreatorId != creatorId)
            // {
            //     throw new Exception("You cannot delete another users Ingredient");
            // }
            // if (!_repo.Delete(id))
            // {
            //     throw new Exception("Something has gone terribly wrong");
            // };
        }
    }
}