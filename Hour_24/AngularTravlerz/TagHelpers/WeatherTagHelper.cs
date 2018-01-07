using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTravlerz.TagHelpers
{


	[HtmlTargetElement("weather")]
	public class WeatherTagHelper : TagHelper
	{

		public string City { get; set; }

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{

			if (string.IsNullOrEmpty(City))
			{
				output.Content.AppendHtml("No city selected");
			}
			else
			{

				var weather = await Weather.WeatherProxy.GetConditions(City);
				output.Content.AppendHtml($"Current conditions in {City} {weather.TempF}F and {weather.Conditions}");

			}

		}

	}
}
