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
}