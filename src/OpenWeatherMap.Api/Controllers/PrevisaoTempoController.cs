using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OpenWeatherMap.Api.Entities;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenWeatherMap.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrevisaoTempoController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        private readonly string _baseUrl = "https://api.openweathermap.org";
        private readonly string _path = "/data/2.5/onecall";
        private readonly string _apiKey = "apiKey";
        private readonly string _unit = "metric";
        private readonly string _dataExcluded = "minutely,hourly,alerts";
        private readonly string _language = "pt_br";

        public PrevisaoTempoController(IMemoryCache cache)
        {
            _cache = cache;
        }

        // GET: /PrevisaoTempo/coordenadas
        [HttpGet]
        public async Task<OpenWeather> GetAsync([FromQuery] double? lat, double? lon)
        {
            if (lat == null) throw new ArgumentNullException(nameof(lat), $"The {nameof(lat)} parameter can not be null.");
            if (lon == null) throw new ArgumentNullException(nameof(lon), $"The {nameof(lon)} parameter can not be null.");

            var cacheKey = $"{lat}+{lon}";
            OpenWeather previsaoTempo = _cache.Get<OpenWeather>(cacheKey);

            if (previsaoTempo != null)
            {
                return previsaoTempo;
            }
            else
            {
                previsaoTempo = await _baseUrl
                    .AppendPathSegment(_path)
                    .SetQueryParam("lat", lat)
                    .SetQueryParam("lon", lon)
                    .SetQueryParam("exclude", _dataExcluded)
                    .SetQueryParam("units", _unit)
                    .SetQueryParam("lang", _language)
                    .SetQueryParam("appid", _apiKey)
                    .GetJsonAsync<OpenWeather>();

                _cache.Set(cacheKey, previsaoTempo);
                return previsaoTempo;
            }
        }
    }
}