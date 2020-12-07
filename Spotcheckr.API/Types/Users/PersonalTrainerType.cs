using System.Threading.Tasks;
using HotChocolate.Types;
using Spotcheckr.API.Services.User;

namespace Spotcheckr.API.Types.Users
{
	public class PersonalTrainerType : ObjectType<PersonalTrainer>
	{
		protected override void Configure(IObjectTypeDescriptor<PersonalTrainer> descriptor)
		{
			descriptor.ImplementsNode()
					  .IdField(prop => prop.ID)
					  .ResolveNode((resolver, id) =>
					  {
						  var userService = resolver.Service<IUserService>();
						  return Task.FromResult(userService.GetPersonalTrainerAsync(id).Result);
					  });
		}
	}
}
