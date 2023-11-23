using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module.Models
{
    public class TMDApiData
    {
        [JsonProperty("app_max_temp")]
        public double AppMaxTemp { get; set; }

        [JsonProperty("app_min_temp")]
        public double AppMinTemp { get; set; }

        [JsonProperty("clouds")]
        public int Clouds { get; set; }

        [JsonProperty("clouds_hi")]
        public int CloudsHi { get; set; }

        [JsonProperty("clouds_low")]
        public int CloudsLow { get; set; }

        [JsonProperty("clouds_mid")]
        public int CloudsMid { get; set; }

        [JsonProperty("datetime")]
        public string Datetime { get; set; }

        [JsonProperty("dewpt")]
        public double Dewpt { get; set; }

        [JsonProperty("high_temp")]
        public double HighTemp { get; set; }

        [JsonProperty("low_temp")]
        public double LowTemp { get; set; }

        [JsonProperty("max_dhi")]
        public object MaxDhi { get; set; }

        [JsonProperty("max_temp")]
        public double MaxTemp { get; set; }

        [JsonProperty("min_temp")]
        public double MinTemp { get; set; }

        [JsonProperty("moon_phase")]
        public double MoonPhase { get; set; }

        [JsonProperty("moon_phase_lunation")]
        public double MoonPhaseLunation { get; set; }

        [JsonProperty("moonrise_ts")]
        public int MoonriseTs { get; set; }

        [JsonProperty("moonset_ts")]
        public int MoonsetTs { get; set; }

        [JsonProperty("ozone")]
        public double Ozone { get; set; }

        [JsonProperty("pop")]
        public int Pop { get; set; }

        [JsonProperty("precip")]
        public double Precip { get; set; }

        [JsonProperty("pres")]
        public double Pres { get; set; }

        [JsonProperty("rh")]
        public int Rh { get; set; }

        [JsonProperty("slp")]
        public double Slp { get; set; }

        [JsonProperty("snow")]
        public int Snow { get; set; }

        [JsonProperty("snow_depth")]
        public int SnowDepth { get; set; }

        [JsonProperty("sunrise_ts")]
        public int SunriseTs { get; set; }

        [JsonProperty("sunset_ts")]
        public int SunsetTs { get; set; }

        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("ts")]
        public int Ts { get; set; }

        [JsonProperty("uv")]
        public double Uv { get; set; }

        [JsonProperty("valid_date")]
        public string ValidDate { get; set; }

        [JsonProperty("vis")]
        public double Vis { get; set; }

        [JsonProperty("weather")]
        public Weather Weather { get; set; }

        [JsonProperty("wind_cdir")]
        public string WindCdir { get; set; }

        [JsonProperty("wind_cdir_full")]
        public string WindCdirFull { get; set; }

        [JsonProperty("wind_dir")]
        public int WindDir { get; set; }

        [JsonProperty("wind_gust_spd")]
        public double WindGustSpd { get; set; }

        [JsonProperty("wind_spd")]
        public double WindSpd { get; set; }
    }

    public class Root
    {
        [JsonProperty("city_name")]
        public string CityName { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("data")]
        public List<TMDApiData> Data { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("state_code")]
        public string StateCode { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }

    public class Weather
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }


}
