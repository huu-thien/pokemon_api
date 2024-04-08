using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Data;
using PokemonReview.Dto;
using PokemonReview.Interfaces;

namespace PokemonReview.Controllers;

[ApiController]
[Route("api/review")]
public class ReviewController : ControllerBase
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<Review>))]
    public IActionResult GetReviews()
    {
        var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(reviews);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Review))]
    [ProducesResponseType(400)]
    public IActionResult GetReviewById(int id)
    {
        if(!_reviewRepository.ReviewExists(id))
        {
            return NotFound();
        }
        var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReviewById(id));
        return Ok(review);
    }

    [HttpGet("/pokemon/{pokemonId}")]
    [ProducesResponseType(200, Type = typeof(List<Review>))]
    [ProducesResponseType(400)]
    public IActionResult GetRreviewOfAPokemon(int pokemonId)
    {
        var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewsOfAPokemon(pokemonId));
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(reviews);
    }
}