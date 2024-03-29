﻿namespace PokemonReview.Data;

public class Reviewer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<Review> Reviews { get; set; }
}