using System;

namespace Spotcheckr.Domain
{
	public class IdentityInformation
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string FullName => $"{FirstName} {LastName}";

		public DateTime? BirthDate { get; set; }
	}
}
