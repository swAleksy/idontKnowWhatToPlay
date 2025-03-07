using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesTracker.DTOs.Game;
using GamesTracker.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GamesTracker.Mappers
{
    public static class GameMappers
    {
        public static GameDto ToGameDto(this Game gameModel)
        {
            return new GameDto
            {
                AppId = gameModel.Appid,
                Name = gameModel.GameName,
                ThumbnailURL = gameModel.ThumbnailURL,
                GameTags = gameModel.GameTags
            };
        }
    }
}