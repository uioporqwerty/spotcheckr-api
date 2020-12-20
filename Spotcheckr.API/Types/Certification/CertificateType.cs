using HotChocolate.Types;
using Spotcheckr.API.Services;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types
{
	public class CertificateType : ObjectType<Certificate>
	{
		protected override void Configure(IObjectTypeDescriptor<Certificate> descriptor)
		{
			descriptor.ImplementsNode()
				.IdField(field => field.Id)
				.ResolveNode(async (ctx, id) => await ctx.Service<ICertificateService>().GetCertificateAsync(id));
			descriptor.Field(field => field.OrganizationId).Ignore();
		}
	}
}
