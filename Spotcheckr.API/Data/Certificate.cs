namespace Spotcheckr.API.Data
{
	public class Certificate
	{
		public int Id { get; set; }

		public string Code { get; set; }

		public string Description { get; set; }

		public int OrganizationId { get; set; }

		public Organization Organization { get; set; }
	}
}
