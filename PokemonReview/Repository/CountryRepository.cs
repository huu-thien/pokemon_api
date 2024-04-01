using PokemonReview.Data;
using PokemonReview.Interfaces;

namespace PokemonReview.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly PokemonDbContext _dbContext;

    public CountryRepository(PokemonDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Country> GetCountries()
    {
        return _dbContext.Countries.OrderBy(c => c.Id).ToList();
    }

    public Country GetCountryById(int id)
    {
        var country = _dbContext.Countries.FirstOrDefault(c => c.Id == id);
        if (country == null)
        {
            throw new Exception("Country not found");
        }
        return country;
    }

    public Country GetCountryByOwner(int ownerId)
    {
        var country = _dbContext.Owners.Where(o => o.Id == ownerId)
            .Select(c => c.Country).FirstOrDefault();
        if (country == null)
            throw new Exception("Owner not found");
        return country;
    }

    public List<Owner> GetOwnersByCountry(int countryId)
    {
        return _dbContext.Owners.Where(o => o.Country.Id == countryId).ToList();
    }

    public bool CountryExists(int id)
    {
        return _dbContext.Countries.Any(c => c.Id == id);
    }
}