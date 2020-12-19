using HotChocolate.Types;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types
{
	public class EmailType : ObjectType<Email>
	{
		protected override void Configure(IObjectTypeDescriptor<Email> descriptor)
		{
			descriptor.Field(field => field.Id).ID(nameof(Email));
			descriptor.Field(field => field.UserId).Ignore();
			descriptor.Field(field => field.User).Ignore();
			descriptor.Field(field => field.DateCreated).Ignore();
			descriptor.Field(field => field.DateModified).Ignore();
		}
	}
}
