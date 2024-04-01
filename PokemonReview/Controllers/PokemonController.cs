using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Data;
using PokemonReview.Dto;
using PokemonReview.Interfaces;

namespace PokemonReview.Controllers;

[ApiController]
[Route("api/pokemon")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IMapper _mapper;
    public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
    {
        _pokemonRepository = pokemonRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<Pokemon>))]
    public IActionResult GetPokemons()
    {
        var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(pokemons);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Pokemon))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonById(int id)
    {
        if (!_pokemonRepository.PokemonExits(id))
        {
            return NotFound();
        }
        var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemonById(id));
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(pokemon);
    }

    [HttpGet("{id}/rating")]
    [ProducesResponseType(200, Type = typeof(decimal))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonRating(int id)
    {
        if (!_pokemonRepository.PokemonExits(id))
        {
            return NotFound();
        }

        decimal rating = _pokemonRepository.GetPokemonRating(id);
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(rating);
    }
}