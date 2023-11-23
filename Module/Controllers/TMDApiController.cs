using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using Module.Models;
using static Module.Models.TMDApiData;

namespace Module.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TMDApiController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public TMDApiController(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _config = config;
        }

        // /TMDAPI/GetDataTMD
        [HttpGet]
        [Route("GetDataTMD")]
        public async Task<IActionResult> GetDataTMD()
        {
            try
            {
                string apiUrl = _config.GetSection("TMDApi:ApiUrlTMD").Value+ _config.GetSection("TMDApi:AccessTokenTMD").Value;
                string accessToken = _config.GetSection("TMDApi:AccessTokenTMD").Value;
                _httpClient.DefaultRequestHeaders.Add("authorization", $"Bearer {accessToken}");
                _httpClient.DefaultRequestHeaders.Add("accept", "application/json");

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {

                    string responseBody = await response.Content.ReadAsStringAsync();
                    Root root = JsonConvert.DeserializeObject<Root>(responseBody);

                    var AllforecastData = root.Data;
                    var forecasts = from forecast in AllforecastData
                                    select new
                                    {
                                        Time = forecast.ValidDate,
                                        DayName = Helper.WeatherHelper.GetDayName(forecast.ValidDate),
                                        Cond = Helper.WeatherHelper.GetConditionDescription(forecast.Weather.Code),
                                        MaxTemperature = forecast.MaxTemp,
                                        MinTemperature = forecast.MinTemp,
                                        WindSpeed = Helper.WeatherHelper.GetWindSpdKmH(forecast.WindSpd)
                                    };

                    return Ok(forecasts);
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return BadRequest($"Error: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}