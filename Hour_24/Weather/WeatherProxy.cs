using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Weather
{
	public class WeatherProxy
	{

		const string myApiKey = "MY-API-KEY";

		public static async Task<WeatherModel> GetConditions(string city)
		{

			var client = new HttpClient();

			var stringResult = await client.GetStringAsync(
				"http://api.openweathermap.org/data/2.5/weather?" +
				$"q={city}&APPID={myApiKey}&units=imperial");
			var json = JObject.Parse(stringResult);

			var outModel = new WeatherModel()
			{
				Conditions = json["weather"][0]["main"].ToString(),
				TempF = decimal.Parse(json["main"]["temp"].ToString())
			};

			return outModel;

		}

		public class WeatherModel
		{

			public decimal TempF { get; set; }

			public string Conditions { get; set; }

		}

	}

}
