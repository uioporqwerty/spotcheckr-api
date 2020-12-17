using System.Collections.Generic;

namespace Spotcheckr.Domain
{
	/// <summary>
	/// Contact information details for the user.
	/// </summary>
	public class ContactInformation
	{
		/// <summary>
		/// Available email addresses for the user.
		/// </summary>
		public IEnumerable<Email> EmailAddresses { get; set; }

		/// <summary>
		/// Available phone numbers for the user.
		/// </summary>
		public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
	}
}
