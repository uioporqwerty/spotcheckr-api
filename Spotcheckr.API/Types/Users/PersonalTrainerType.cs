using HotChocolate.Types;
using Spotcheckr.API.Services;
using Spotcheckr.Models;

namespace Spotcheckr.API.Types
{
	public class PersonalTrainerType : ObjectType<PersonalTrainer>
	{
		protected override void Configure(IObjectTypeDescriptor<PersonalTrainer> descriptor)
		{
			descriptor.Implements<IUserType>();
			descriptor.ImplementsNode()
					  .IdField(prop => prop.Id)
					  .ResolveNode(async (resolver, id) =>
					  {
						  var userService = resolver.Service<IUserService>();
						  var user = await userService.GetUserAsync(id);
						  return user as PersonalTrainer;
					  });
		}
	}
}
