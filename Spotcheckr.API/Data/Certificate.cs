﻿namespace Spotcheckr.API.Data
{
	public class Certificate
	{
		public int CertificateId { get; set; }

		public string Description { get; set; }

		public Organization Organization { get; set; }

		public int OrganizationId { get; set; }
	}
}
