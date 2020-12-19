using HotChocolate.Types;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types
{
	public class EmailInputType : InputObjectType<Email>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Email> descriptor)
		{
			descriptor.Field(field => field.Id).ID(nameof(Email));
			descriptor.Field(field => field.UserId).Ignore();
			descriptor.Field(field => field.User).Ignore();
			descriptor.Field(field => field.DateCreated).Ignore();
			descriptor.Field(field => field.DateModified).Ignore();
		}
	}
}
