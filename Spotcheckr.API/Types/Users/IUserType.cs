using HotChocolate.Types;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.Types
{
	public class IUserType : InterfaceType<IUser>
	{
		protected override void Configure(IInterfaceTypeDescriptor<IUser> descriptor)
		{
			descriptor.Field(t => t.Id).Type<NonNullType<IdType>>();
		}
	}
}
