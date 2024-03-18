using PokemonReview.Data;

namespace PokemonReview.Interfaces;

public interface IPokemonRepository
{
    List<Pokemon> GetPokemons();
    
    
}