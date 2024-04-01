using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Data;
using PokemonReview.Dto;
using PokemonReview.Interfaces;

namespace PokemonReview.Controllers;

[ApiController]
[Route("api/country")]
public class CountryController : ControllerBase
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    
    public CountryController(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<Country>))]
    public IActionResult GetCountries()
    {
        var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(countries);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    [ProducesResponseType(400)]
    public IActionResult GetCountryById(int id)
    {
        if (!_countryRepository.CountryExists(id))
        {
            return NotFound();
        }
        var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryById(id));
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(country);
    }
    
    // [HttpGet("{id}/owners")]
    // [ProducesResponseType(200, Type = typeof(List<Owner>))]
    // [ProducesResponseType(400)]
    // public IActionResult GetOwnersByCountry(int id)
    // {
    //     if (!_countryRepository.CountryExists(id))
    //     {
    //         return NotFound();
    //     }
    //     var owners = _mapper.Map<List<OwnerDto>>(_countryRepository.GetOwnersByCountry(id));
    //     if (!ModelState.IsValid) return BadRequest(ModelState);
    //     return Ok(owners);
    // }
    
    [HttpGet("/owner/{ownerId}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    [ProducesResponseType(400)]
    public IActionResult GetCountryByOwner(int ownerId)
    {
        var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(country);
    }
    
}