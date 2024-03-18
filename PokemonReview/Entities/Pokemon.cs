namespace PokemonReview.Data;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public List<Review> Reviews { get; set; }
    public List<PokemonOwner> PokemonOwners { get; set; }
    public List<PokemonCategory> PokemonCategories { get; set; }
}