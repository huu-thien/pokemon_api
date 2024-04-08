using PokemonReview.Data;
using PokemonReview.Interfaces;

namespace PokemonReview.Repository;

public class ReviewerRepository : IReviewerRepository
{
    private readonly PokemonDbContext _context;

    public ReviewerRepository(PokemonDbContext context)
    {
        _context = context;
    }

    public List<Reviewer> GetReviewers()
    {
        return _context.Reviewers.ToList();
    }

    public Reviewer GetReviewerById(int id)
    {
        var reviewer = _context.Reviewers.FirstOrDefault(r => r.Id == id);
        if(reviewer == null) throw new Exception("Reviewer not found");
        return reviewer;
    }

    public List<Review> GetReviewsByReviewer(int reviewerId)
    {
        return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
    }

    public bool ReviewerExists(int id)
    {
        return _context.Reviewers.Any(r => r.Id == id);
    }
}