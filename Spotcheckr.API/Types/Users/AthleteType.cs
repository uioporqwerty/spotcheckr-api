using HotChocolate.Types;
using Spotcheckr.API.Services;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types.Users
{
	public class AthleteType : ObjectType<Athlete>
	{
		protected override void Configure(IObjectTypeDescriptor<Athlete> descriptor)
		{
			descriptor.Implements<IUserType>();
			descriptor.ImplementsNode()
					  .IdField(prop => prop.Id)
					  .ResolveNode(async (resolver, id) =>
					  {
						  var userService = resolver.Service<IUserService>();
						  var user = await userService.GetUserAsync(id);
						  return user as Athlete;
					  });
		}
	}
}
