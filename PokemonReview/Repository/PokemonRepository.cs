using PokemonReview.Data;
using PokemonReview.Interfaces;

namespace PokemonReview.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly PokemonDbContext _dbContext;
    public PokemonRepository(PokemonDbContext context)
    {
        _dbContext = context;
    }
    
    public List<Pokemon> GetPokemons()
    {
        return _dbContext.Pokemons.OrderBy(p => p.Id).ToList();
    }

    public Pokemon GetPokemonById(int id)
    {
        var pokemon =  _dbContext.Pokemons.FirstOrDefault(p => p.Id == id);
        if (pokemon == null)
        {
            throw new Exception("Pokemon not found");
        }
        return pokemon;
    }

    public Pokemon GetPokemonByName(string name)
    {
        var pokemon = _dbContext.Pokemons.FirstOrDefault(p => p.Name == name);
        if (pokemon == null)
        {
            throw new Exception("Pokemon not found");
        }

        return pokemon;
    }

    public decimal GetPokemonRating(int id)
    {
        var review = _dbContext.Reviews.Where(p => p.Pokemon.Id == id);
        if (!review.Any())
        {
            return 0;
        }
        return (decimal)review.Sum(r => r.Rating) / review.Count();
    }

    public bool PokemonExits(int id)
    {
        return _dbContext.Pokemons.Any(p => p.Id == id);
    }
}