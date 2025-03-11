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
        Task<IEnumerable<OwnedGame>> GetOwnedGamesAsync(string steamId);
        Task<IEnumerable<WishlistItem>> GetWishlistAsync(string steamId);
        Task<(string Name, string HeaderImage)?> GetGameDetailsAsync(string appId);
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

        public async Task<IEnumerable<OwnedGame>> GetOwnedGamesAsync(string steamId)
        {
            var response = await _httpClient.GetAsync($"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={_apiKey}&steamid={steamId}&format=json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            

            var options = new JsonSerializerOptions { 
                PropertyNameCaseInsensitive = true 
            };

            // Console.WriteLine(content);
            var responseObject = JsonSerializer.Deserialize<SteamOwnedGamesResponse>(content, options);      
            return SteamApiMappers.MapOwnedGamesToModels(responseObject);
        }

        public async Task<IEnumerable<WishlistItem>> GetWishlistAsync(string steamId)
        {
            var response = await _httpClient.GetAsync($"https://api.steampowered.com/IWishlistService/GetWishlist/v1/?steamid={steamId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            
            var options = new JsonSerializerOptions { 
                PropertyNameCaseInsensitive = true 
            };
            
            var wishlistItems = JsonSerializer.Deserialize<SteamWishlistResponse>(content, options);
            return SteamApiMappers.MapWishlistToModels(wishlistItems);
        }

        public async Task<(string Name, string HeaderImage)?> GetGameDetailsAsync(string appId)
        {
            var response = await _httpClient.GetAsync($"https://store.steampowered.com/api/appdetails?appids={appId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(content);
            var root = doc.RootElement;

            if (root.TryGetProperty(appId, out var appElement) && appElement.TryGetProperty("success", out var successElement) && successElement.GetBoolean() && appElement.TryGetProperty("data", out var dataElement))
            {
                var name = dataElement.GetProperty("name").GetString();
                var imageUrl = dataElement.GetProperty("header_image").GetString();
                return (name, imageUrl);
            }

             
            return null;
        }
    }
}