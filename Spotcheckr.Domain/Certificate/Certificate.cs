namespace Spotcheckr.API.Domain
{
	public class Certificate
	{
		public Certificate(string code, string description)
		{
			Code = code;
			Description = description;
		}

		public int Id { get; set; }

		public string Code { get; set; }

		public string Description { get; set; }

		public int OrganizationId { get; set; }

		public Organization Organization { get; set; }
	}
}
