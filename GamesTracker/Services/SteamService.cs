using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GamesTracker.DTOs.Steam;
using GamesTracker.Models;
using GamesTracker.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GamesTracker.Services
{

    public interface ISteamService
    {
        Task<IEnumerable<Game>> GetOwnedGamesAsync(string steamId);
        Task<IEnumerable<Game>> GetWishlistAsync(string steamId);
    }

    public class SteamService : ISteamService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public SteamService (HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Steam:ApiKey"];
        }

        public async Task<IEnumerable<Game>> GetOwnedGamesAsync(string steamId)
        {
            var response = await _httpClient.GetAsync($"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={_apiKey}&steamid={steamId}&format=json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<SteamOwnedGamesResponse>(content);

            return SteamApiMappers.MapOwnedGamesToModels(responseObject);
        }

        public async Task<IEnumerable<Game>> GetWishlistAsync(string steamId)
        {
            var response = await _httpClient.GetAsync($"https://api.steampowered.com/IWishlistService/GetWishlist/v1/?steamid={steamId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var wishlistItems = JsonSerializer.Deserialize<SteamWishlistResponse>(content);
            
            // Map Steam wishlist response to your Game model
            return SteamApiMappers.MapWishlistToModels(wishlistItems);
        }
    }


}