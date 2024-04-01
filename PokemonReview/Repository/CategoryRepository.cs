using AutoMapper;
using PokemonReview.Data;
using PokemonReview.Interfaces;

namespace PokemonReview.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly PokemonDbContext _dbContext;

    public CategoryRepository(PokemonDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    
    public List<Category> GetCategories()
    {
        return _dbContext.Categories.OrderBy(c => c.Id).ToList();
    }

    public Category GetCategoryById(int id)
    {
        var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            throw new Exception("Category not found");
        }
        return category;
    }

    public List<Pokemon> GetPokemonsByCategory(int id)
    {
        return _dbContext.PokemonCategories.Where(pc => pc.CategoryId == id)
            .Select(pc => pc.Pokemon).ToList();
    }

    public bool CategoryExists(int id)
    {
        return _dbContext.Categories.Any(c => c.Id == id);
    }
}