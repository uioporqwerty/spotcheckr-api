using System.Collections.Generic;

namespace Spotcheckr.Domain
{
	public class ContactInformation
	{
		public IEnumerable<Email> EmailAddresses { get; set; }

		public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
	}
}
