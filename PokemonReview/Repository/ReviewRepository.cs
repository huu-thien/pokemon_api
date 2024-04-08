using PokemonReview.Data;
using PokemonReview.Interfaces;

namespace PokemonReview.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly PokemonDbContext _context;

    public ReviewRepository(PokemonDbContext context)
    {
        _context = context;
    }
    
    public List<Review> GetReviews()
    {
        return _context.Reviews.ToList();
    }

    public Review GetReviewById(int id)
    {
        var review = _context.Reviews.FirstOrDefault(r => r.Id == id);
        if(review == null) throw new Exception("Review not found");
        return review;
    }

    public List<Review> GetReviewsOfAPokemon(int pokemonId)
    {
        return _context.Reviews.Where(r => r.Pokemon.Id == pokemonId).ToList();
    }

    public bool ReviewExists(int id)
    {
        return _context.Reviews.Any(r => r.Id == id);
    }
}