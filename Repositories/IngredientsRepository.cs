
using System;
using System.Collections.Generic;
using System.Data;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Ingredient> GetAll()
        {
            string sql = "SELECT * FROM ingredients";
            return _db.Query<Ingredient>(sql);
        }

        internal IEnumerable<Ingredient> GetByRecipesId(string id)
        {
            string sql = "SELECT * FROM ingredients WHERE recipeId = @id";
            return _db.Query<Ingredient>(sql, new { id });
        }
        internal Ingredient GetById(int id)
        {
            string sql = "SELECT * FROM ingredients WHERE id = @id";
            return _db.QueryFirstOrDefault<Ingredient>(sql, new { id });
        }

        internal Ingredient Create(Ingredient newIngredient)
        {
            string sql = @"
      INSERT INTO ingredients
      (Id, recipesId, name, quantity)
      VALUES
      (@Id, @RecipesId, @Name, @Quantity);
      SELECT LAST_INSERT_ID()";
            newIngredient.Id = _db.ExecuteScalar<int>(sql, newIngredient);
            return newIngredient;
        }

        internal bool Delete(int id)
        {
            string sql = "DELETE FROM ingredients WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }
    }
}