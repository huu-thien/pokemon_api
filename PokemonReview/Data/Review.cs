﻿namespace PokemonReview.Data;

public class Review
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
}