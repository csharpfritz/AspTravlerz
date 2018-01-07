using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspTravlerz.Models
{
	public class Trip : IValidatableObject
	{

		public Trip()
		{
			Segments = new List<Segment>();
		}


		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }

    public string Destination { get; set; }

    public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public List<Segment> Segments { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var myTrip = (Trip)validationContext.ObjectInstance;
			var results = new List<ValidationResult>();
			if (myTrip.StartDate > myTrip.EndDate)
			{
				var msg = "Start Date cannot occur before End Date";
				var fields = new[] { "StartDate", "EndDate" };
				results.Add(new ValidationResult(msg, fields));
			}
			return results;
		}
	}

}
