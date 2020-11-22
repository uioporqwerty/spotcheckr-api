using System;

namespace Spotcheckr.API.Data
{
	public class Certification
	{
		public int Id { get; set; }

		public string? Number { get; set; }

		public bool Verified { get; set; } = false;

		public DateTime? DateAchieved { get; set; }

		public Certificate Certificate { get; set; }
	}
}
