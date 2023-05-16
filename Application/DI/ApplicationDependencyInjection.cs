using Application.Helpers;
using Microsoft.Extensions.DependencyInjection;
using NotSpotify.Application.Common.Interfaces.Services;
using NotSpotifyAPI.Application.Services;

namespace Application.DI
{
    public static class ApplicationDependencyInjection
    {

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<IPlaylistService, PlaylistService>();
            services.AddScoped<ISongService, SongService>();
        }


    }
}
