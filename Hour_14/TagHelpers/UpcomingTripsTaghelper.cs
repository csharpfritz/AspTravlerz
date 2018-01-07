using System;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using AspTravlerz.Models;

namespace AspTravlerz.TagHelpers
{

  /// <summary>
  /// Output a collection of upcoming trips
  /// </summary>
  [HtmlTargetElement("upcoming")]
  public class UpcomingTripsTagHelper : TagHelper
  {

    public UpcomingTripsTagHelper(TripRepository repo)
    {
      this.Repository = repo;
    }

    [HtmlAttributeNotBound()]
    public TripRepository Repository { get; }

    /// <summary>
    /// The maximum number of trips to present
    /// </summary>
    public int Count { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {

      output.TagName = "div";

      var newClass = "upcoming-mini";
      if (output.Attributes.ContainsName("class"))
      {
        newClass += " " + output.Attributes["class"].Value;
        output.Attributes.Remove(output.Attributes["class"]);
      }
      output.Attributes.Add("class", newClass);

      output.PreContent.AppendHtml("<h4>Trips TagHelper</h4>");

      output.Content.AppendHtml("<ul>");

      var trips = Repository.Get()
        .Where(t => t.EndDate > DateTime.Today)
        .OrderBy(t => t.EndDate)
        .Take(Count);



      foreach (var trip in trips)
      {
        var url = $"/trips/details/{trip.ID}";
        output.Content.AppendHtml($"<li><a href=\"{url}\">{trip.Name}</a> ({trip.StartDate.ToString("d")}-{trip.EndDate.ToString("d")})</li>");
      }

      output.Content.AppendHtml("</ul>");

    }

  }
}
