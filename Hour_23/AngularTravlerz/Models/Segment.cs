using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspTravlerz.Models
{
	/// <summary>
	/// A reservation or some other event that has been scheduled to occur during a trip
	/// </summary>
	public class Segment
	{

		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		public int TripID { get; set; }

		[ForeignKey("TripID")]
		public Trip Trip { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public SegmentType Type { get; set; }

		[ScaffoldColumn(false)]
		public string SegmentType { get { return Enum.GetName(typeof(SegmentType), Type); } }

		public string ReservationID { get; set; }

		/// <summary>
		/// Can be a flight seat, train class of transportation
		/// </summary>
		public string ReservationLocation { get; set; }

		public string DepartureAddress { get; set; }

		public string ArrivalAddress { get; set; }

	}

}

