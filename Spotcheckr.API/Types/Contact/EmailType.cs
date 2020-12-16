using HotChocolate.Types;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types.Contact
{
	public class EmailType : ObjectType<Email>
	{
		protected override void Configure(IObjectTypeDescriptor<Email> descriptor)
		{
			descriptor.Description("Email address details.");
			descriptor.Field(field => field.Id).ID(nameof(Email)).Description("Unique identifier for email address.");
			descriptor.Field(field => field.Address).Description("Email address value.");
			descriptor.Field(field => field.UserId).Ignore();
			descriptor.Field(field => field.User).Ignore();
			descriptor.Field(field => field.DateCreated).Ignore();
			descriptor.Field(field => field.DateModified).Ignore();
		}
	}
}
