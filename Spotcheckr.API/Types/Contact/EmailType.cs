using HotChocolate.Types;
using Spotcheckr.Models;

namespace Spotcheckr.API.Types
{
	public class EmailType : ObjectType<Email>
	{
		protected override void Configure(IObjectTypeDescriptor<Email> descriptor)
		{
			descriptor.Field(field => field.Id).ID(nameof(Email));
		}
	}
}
