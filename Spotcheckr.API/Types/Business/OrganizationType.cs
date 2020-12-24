using HotChocolate.Types;
using Spotcheckr.API.Services;
using Spotcheckr.Models;

namespace Spotcheckr.API.Types
{
	public class OrganizationType : ObjectType<Organization>
	{
		protected override void Configure(IObjectTypeDescriptor<Organization> descriptor)
		{
			descriptor.ImplementsNode()
					  .IdField(field => field.Id)
					  .ResolveNode(async (ctx, id) => await ctx.Service<IOrganizationService>().GetOrganizationAsync(id));
		}
	}
}
