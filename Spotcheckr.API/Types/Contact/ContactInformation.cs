using System.Collections.Generic;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types.Contact
{
	public class ContactInformation
	{
		public IEnumerable<Email> EmailAddresses { get; set; }

		public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
	}
}
