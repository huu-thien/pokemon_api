namespace PokemonReview.Data;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Owner> Owners { get; set; }
}