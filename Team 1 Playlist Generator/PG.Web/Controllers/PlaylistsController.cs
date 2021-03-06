﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PG.Models;
using PG.Services.Contract;
using PG.Services.DTOs;
using PG.Web.Models;
using PG.Web.Models.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PG.Web.Controllers
{
    [Authorize]
    public class PlaylistsController : Controller
    {
        private readonly IPlaylistService _playlistService;
        private readonly IGenreService _genreService;
        private readonly IBingMapsAPIService _bingMapsAPIService;
        private readonly UserManager<User> _userManager;

        public PlaylistsController(IPlaylistService playlistService, IGenreService genreService, IBingMapsAPIService bingMapsAPIService,
            UserManager<User> userManager)
        {
            _playlistService = playlistService;
            _genreService = genreService;
            _bingMapsAPIService = bingMapsAPIService;
            this._userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<PlaylistDTO> playlistsDTOs = await _playlistService.GetAllPlaylists();
            IList<PlaylistViewModel> playlistsViewModels = playlistsDTOs.Select(x => x.ToViewModel()).ToList();

            return View(playlistsViewModels);
        }

        public async Task<IActionResult> MyPlaylists()
        {
            IEnumerable<PlaylistDTO> playlistsDTOs = await _playlistService.GetAllPlaylists();
            IList<PlaylistViewModel> playlistsViewModels = playlistsDTOs.Where(x => x.UserId == _userManager.GetUserId(User)).Select(x => x.ToViewModel()).ToList();

            return View(playlistsViewModels);
        }

        public async Task<IActionResult> Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }

            var genresDTOs = await _genreService.GetAllGenres();

            var genresViewModels = genresDTOs.Select(x => x.ToViewModel());

            var playlistGenerator = new PlaylistGeneratorViewModel();

            playlistGenerator.Genres = genresViewModels.ToList();


            return View(playlistGenerator);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Playlist(int id)
        {
            PlaylistDTO playlistDTO = await _playlistService.GetPlaylistById(id);
            PlaylistViewModel playlistViewModel = playlistDTO.ToViewModel();

            return View(playlistViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlaylistGeneratorViewModel formInput)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }

            int tripTime = await _bingMapsAPIService.FindDuration(formInput.StartLocation, formInput.EndLocation);

            var user = await _userManager.GetUserAsync(User);

            await _playlistService.GeneratePlaylist(tripTime, formInput.PlaylistName,
                formInput.Metal, formInput.Rock, formInput.Pop, formInput.TopTracks, formInput.SameArtist, user);

            return RedirectToAction("Index");
        }
    }
}
