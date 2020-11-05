﻿using PG.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PG.Services.Contract
{
    public interface IPlaylistService
    {
        Task<PlaylistDTO> Create(PlaylistDTO playlistDTO);
        Task<IEnumerable<PlaylistDTO>> GetPlaylistsByUser(int userId);
        Task<PlaylistDTO> GetPlaylistById(int id);
        Task<IEnumerable<PlaylistDTO>> GetAllPlaylists();
        Task<PlaylistDTO> Update(int id, PlaylistDTO playlistDTO);
        Task<bool> Delete(int id);
    }
}   
