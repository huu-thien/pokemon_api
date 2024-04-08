using PokemonReview.Data;

namespace PokemonReview.Interfaces;

public interface IOwnerRepository
{
    List<Owner> GetOwners();
    Owner GetOwnerById(int id);
    List<Owner> GetOwnerOfAPokemon(int pokemonId);
    List<Pokemon> GetPokemonByOwner(int ownerId);
    bool OwnerExists(int id);
}