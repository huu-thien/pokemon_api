using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Data;
using PokemonReview.Interfaces;

namespace PokemonReview.Dto;

[ApiController]
[Route("api/reviewer")]
public class ReviewerController : ControllerBase
{
    private readonly IReviewerRepository _reviewerRepository;
    private readonly IMapper _mapper;

    public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
    {
        _reviewerRepository = reviewerRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<Reviewer>))]
    public IActionResult GetReviewers()
    {
        var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewers());
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(reviewers);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Reviewer))]
    [ProducesResponseType(400)]
    public IActionResult GetReviewerById(int id)
    {
        if(!_reviewerRepository.ReviewerExists(id))
        {
            return NotFound();
        }
        var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewerById(id));
        return Ok(reviewer);
    }
    
    [HttpGet("/review/{reviewId}")]
    [ProducesResponseType(200, Type = typeof(List<Review>))]
    [ProducesResponseType(400)]
    public IActionResult GetReviewsByReviewer(int reviewId)
    {
        var reviews = _mapper.Map<List<ReviewDto>>(_reviewerRepository.GetReviewsByReviewer(reviewId));
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(reviews);
    }
}