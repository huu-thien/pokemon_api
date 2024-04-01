using PokemonReview.Data;

namespace PokemonReview.Interfaces;

public interface ICountryRepository
{
    List<Country> GetCountries();
    Country GetCountryById(int id);
    Country GetCountryByOwner(int ownerId);
    List<Owner> GetOwnersByCountry(int countryId);
    bool CountryExists(int id);
}