﻿using PG.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PG.Services.Contract
{
    public interface IArtistService
    {
        Task<ArtistDTO> Create(ArtistDTO ArtistDTO);
        Task<ArtistDTO> GetArtistById(int id);
        Task<IEnumerable<ArtistDTO>> GetAllArtists();
        Task<ArtistDTO> Update(int id, ArtistDTO artistDTO);
        Task<bool> Delete(int id);
    }
}
