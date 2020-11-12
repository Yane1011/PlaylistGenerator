﻿using PG.Models;
using PG.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PG.Services.Mappers
{
    public static class ArtistMapper
    {
        public static ArtistDTO ToDTO(this Artist artist)
        {
            return new ArtistDTO()
            {
                Id = artist.Id,
                Name = artist.Name,
                Tracklist = artist.Tracklist,
                Type = artist.Type
            };
        }
        public static Artist ToModel(this ArtistDTO artistDTO)
        {
            return new Artist()
            {
                Id = artistDTO.Id,
                Name = artistDTO.Name,
                Tracklist = artistDTO.Tracklist,
                Type = artistDTO.Type
            };
        }
    }
}
