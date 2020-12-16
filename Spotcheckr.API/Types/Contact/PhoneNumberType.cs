using HotChocolate.Types;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types.Contact
{
	public class PhoneNumberType : ObjectType<PhoneNumber>
	{
		protected override void Configure(IObjectTypeDescriptor<PhoneNumber> descriptor)
		{
			descriptor.Description("Phone number details.");
			descriptor.Field(field => field.Id).ID(nameof(PhoneNumber)).Description("Unique identifier for phone number.");
			descriptor.Field(field => field.Number).Description("Value of phone number.");
			descriptor.Field(field => field.Extension).Description("Extension value of phone number.");
			descriptor.Field(field => field.UserId).Ignore();
			descriptor.Field(field => field.User).Ignore();
			descriptor.Field(field => field.DateCreated).Ignore();
			descriptor.Field(field => field.DateModified).Ignore();
		}
	}
}
