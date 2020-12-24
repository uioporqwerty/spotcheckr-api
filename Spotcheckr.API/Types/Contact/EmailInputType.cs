using HotChocolate.Types;
using Spotcheckr.Models;

namespace Spotcheckr.API.Types
{
	public class EmailInputType : InputObjectType<Email>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Email> descriptor)
		{
			descriptor.Field(field => field.Id).ID(nameof(Email));
		}
	}
}
