﻿using AutoMapper;
using PokemonReview.Data;
using PokemonReview.Dto;

namespace PokemonReview.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pokemon, PokemonDto>();
    }
}