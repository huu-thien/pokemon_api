using PokemonReview.Data;
using PokemonReview.Interfaces;

namespace PokemonReview.Repository;

public class OwnerRepository : IOwnerRepository
{
    private readonly PokemonDbContext _context;

    public OwnerRepository(PokemonDbContext context)
    {
        _context = context;
    }
    
    public List<Owner> GetOwners()
    {
        return _context.Owners.ToList();
    }

    public Owner GetOwnerById(int id)
    {
        var owner = _context.Owners.FirstOrDefault(o => o.Id == id);
        if(owner == null) throw new Exception("Owner not found");
        return owner;
    }

    public List<Owner> GetOwnerOfAPokemon(int pokemonId)
    {
        return _context.PokemonOwners.Where(po => po.PokemonId == pokemonId)
            .Select(po => po.Owner).ToList();
    }

    public List<Pokemon> GetPokemonByOwner(int ownerId)
    {
        return _context.PokemonOwners.Where(po => po.OwnerId == ownerId)
            .Select(po => po.Pokemon).ToList();
    }

    public bool OwnerExists(int id)
    {
        return _context.Owners.Any(o => o.Id == id );
    }
}