using HotChocolate.Types;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types.Identity
{
	public class IdentityInformationType : ObjectType<IdentityInformation>
	{
		protected override void Configure(IObjectTypeDescriptor<IdentityInformation> descriptor)
		{
			descriptor.Description("Identity details for the user.");
			descriptor.Field(field => field.FirstName).Description("User first name.");
			descriptor.Field(field => field.LastName).Description("User last name.");
			descriptor.Field(field => field.BirthDate).Description("User birth date.");
		}
	}
}
