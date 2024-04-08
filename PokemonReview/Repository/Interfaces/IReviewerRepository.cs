using PokemonReview.Data;

namespace PokemonReview.Interfaces;

public interface IReviewerRepository
{
    List<Reviewer> GetReviewers();
    Reviewer GetReviewerById(int id);
    List<Review> GetReviewsByReviewer(int reviewerId);
    bool ReviewerExists(int id);
}