using HotChocolate.Types;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types.Contact
{
	public class ContactInformationType : ObjectType<ContactInformation>
	{
		protected override void Configure(IObjectTypeDescriptor<ContactInformation> descriptor)
		{
			descriptor.Description("Contact information details for the user.");
			descriptor.Field(field => field.PhoneNumbers).Description("Available phone numbers for the user.");
			descriptor.Field(field => field.EmailAddresses).Description("Available email addresses for the user.");
		}
	}
}
