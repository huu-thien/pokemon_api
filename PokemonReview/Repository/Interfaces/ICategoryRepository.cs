using PokemonReview.Data;

namespace PokemonReview.Interfaces;

public interface ICategoryRepository
{
    List<Category> GetCategories();
    Category GetCategoryById(int id);
    List<Pokemon> GetPokemonsByCategory(int id);
    bool CategoryExists(int id);

}