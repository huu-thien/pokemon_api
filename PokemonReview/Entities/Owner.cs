namespace PokemonReview.Data;

public class Owner
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gym {get; set; } = null!;
    public Country Country { get; set; }
    public List<PokemonOwner> PokemonOwners { get; set; }
}