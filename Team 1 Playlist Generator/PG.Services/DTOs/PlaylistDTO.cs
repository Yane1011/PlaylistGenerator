﻿using PG.Models;
using PG.Services.DTOs.Abstract;
using System.Collections.Generic;

namespace PG.Services.DTOs
{
    public class PlaylistDTO : EntityDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public string Picture { get; set; }

        public int UserId { get; set; }

        public ICollection<PlaylistsSongs> PlaylistsSongs { get; set; } = new List<PlaylistsSongs>();
    }
}
