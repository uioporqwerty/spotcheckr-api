using HotChocolate.Types;
using Spotcheckr.API.Services;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types.Users
{
	public class AthleteType : ObjectType<Athlete>
	{
		protected override void Configure(IObjectTypeDescriptor<Athlete> descriptor)
		{
			descriptor.Description("Athlete type of user with details specific to an athlete.");
			descriptor.Field(field => field.Id).Description("Unique identifier for the user.");
			descriptor.Field(field => field.Username).Description("Username for the user.");
			descriptor.Field(field => field.ProfilePicture).Description("URL for the profile picture uploaded by the user.");
			descriptor.Field(field => field.IdentityInformation).Description("Details surrounding the identity of the user.");
			descriptor.Field(field => field.ContactInformation).Description("Contact details for the user.");
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
