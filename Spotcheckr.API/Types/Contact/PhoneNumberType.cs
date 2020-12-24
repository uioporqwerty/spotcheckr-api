using HotChocolate.Types;
using Spotcheckr.Models;

namespace Spotcheckr.API.Types
{
	public class PhoneNumberType : ObjectType<PhoneNumber>
	{
		protected override void Configure(IObjectTypeDescriptor<PhoneNumber> descriptor)
		{
			descriptor.Field(field => field.Id).ID(nameof(PhoneNumber));
		}
	}
}
