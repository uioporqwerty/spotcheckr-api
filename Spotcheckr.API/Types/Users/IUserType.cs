using HotChocolate.Types;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types.Users
{
	public class IUserType : InterfaceType<IUser>
	{
		protected override void Configure(IInterfaceTypeDescriptor<IUser> descriptor)
		{
			descriptor.Field(t => t.Id).Type<NonNullType<IdType>>();
		}
	}
}
