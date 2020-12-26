namespace Spotcheckr.API.Models
{
	/// <summary>
	/// Fitness service provider specific certificates issued to personal trainers.
	/// </summary>
	public class Certificate
	{
		public Certificate(string code, string description)
		{
			Code = code;
			Description = description;
		}

		/// <summary>
		/// Unique identifier for a certificate.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Organization issued code for a certificate. Unique across all certificates for
		/// a given organization.
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// Brief description of the certificate.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Issuing organization for a certificate.
		/// </summary>
		public Organization Organization { get; set; }
	}
}
