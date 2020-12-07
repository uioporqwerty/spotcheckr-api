using System;
using System.Collections.Generic;

namespace Spotcheckr.Domain
{
	public class PersonalTrainer : IUser
	{
		public int ID { get; set; }

		public string? Username { get; set; }

		public Uri? ProfilePicture { get; set; }

		public IdentityInformation IdentityInformation { get; set; }

		public ContactInformation? ContactInformation { get; set; }

		public Uri? Website { get; set; }

		public IEnumerable<Certification>? Certifications { get; set; }
	}
}
