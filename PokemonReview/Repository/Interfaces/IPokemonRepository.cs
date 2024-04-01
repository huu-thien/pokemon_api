using PokemonReview.Data;

namespace PokemonReview.Interfaces;

public interface IPokemonRepository
{
    List<Pokemon> GetPokemons();
    
    Pokemon GetPokemonById(int id);
    Pokemon GetPokemonByName(string name);
    decimal GetPokemonRating(int id);
    bool PokemonExits(int id);
}