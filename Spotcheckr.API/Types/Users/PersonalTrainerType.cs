using System.Threading.Tasks;
using HotChocolate.Types;
using Spotcheckr.API.Services.User;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types.Users
{
	public class PersonalTrainerType : ObjectType<PersonalTrainer>
	{
		protected override void Configure(IObjectTypeDescriptor<PersonalTrainer> descriptor)
		{
			descriptor.Description("Personal trainer type of user with details specific to a personal trainer.");
			descriptor.Field(field => field.ID).Description("Unique identifier for the user.");
			descriptor.Field(field => field.Username).Description("Username for the user.");
			descriptor.Field(field => field.ProfilePicture)
				.Description("URL for the profile picture uploaded by the user.");
			descriptor.Field(field => field.IdentityInformation)
				.Description("Details surrounding the identity of the user.");
			descriptor.Field(field => field.ContactInformation).Description("Contact details for the user.");
			descriptor.Field(field => field.Website)
				.Description("Business or personal website for the personal trainer.");
			descriptor.Field(field => field.Certifications)
				.Description("Certifications achieved by the personal trainer.");
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
