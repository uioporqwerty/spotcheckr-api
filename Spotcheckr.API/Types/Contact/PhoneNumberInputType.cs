using HotChocolate.Types;
using Spotcheckr.Models;

namespace Spotcheckr.API.Types
{
	public class PhoneNumberInputType : InputObjectType<PhoneNumber>
	{
		protected override void Configure(IInputObjectTypeDescriptor<PhoneNumber> descriptor)
		{
			descriptor.Field(field => field.Id).ID(nameof(PhoneNumber));
		}
	}
}
