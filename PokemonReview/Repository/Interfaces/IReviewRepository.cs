using PokemonReview.Data;

namespace PokemonReview.Interfaces;

public interface IReviewRepository
{
    List<Review> GetReviews();
    Review GetReviewById(int id);
    List<Review> GetReviewsOfAPokemon(int pokemonId);
    bool ReviewExists(int id);
}