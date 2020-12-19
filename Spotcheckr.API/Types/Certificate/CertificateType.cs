using HotChocolate.Types;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types
{
	public class CertificateType : ObjectType<Certificate>
	{
		protected override void Configure(IObjectTypeDescriptor<Certificate> descriptor)
		{
			descriptor.Field(field => field.OrganizationId).Ignore();
		}
	}
}
