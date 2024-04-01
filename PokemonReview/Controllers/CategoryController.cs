using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Data;
using PokemonReview.Dto;
using PokemonReview.Interfaces;

namespace PokemonReview.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<Category>))]
    public IActionResult GetCategories()
    {
        var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
        if(!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(categories);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Category))]
    [ProducesResponseType(400)]
    public IActionResult GetCategoryById(int id)
    {
        if (!_categoryRepository.CategoryExists(id))
        {
            return NotFound();
        }
        var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategoryById(id));
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(category);
    }

    [HttpGet("{id}/pokemons")]
    [ProducesResponseType(200, Type = typeof(List<Pokemon>))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonsByCategory(int id)
    {
        if (!_categoryRepository.CategoryExists(id))
        {
            return NotFound();
        }
        var pokemons = _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonsByCategory(id)); 
        if(!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(pokemons);
    }
}