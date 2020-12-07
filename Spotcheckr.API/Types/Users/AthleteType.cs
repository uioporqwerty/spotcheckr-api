using System.Threading.Tasks;
using HotChocolate.Types;
using Spotcheckr.API.Services.User;

namespace Spotcheckr.API.Types.Users
{
	public class AthleteType : ObjectType<Athlete>
	{
		protected override void Configure(IObjectTypeDescriptor<Athlete> descriptor)
		{
			descriptor.ImplementsNode()
				.IdField(prop => prop.ID)
				.ResolveNode((resolver, id) =>
				{
					var userService = resolver.Service<IUserService>();
					return Task.FromResult(userService.GetAthleteAsync(id).Result);
				});
		}
	}
}
