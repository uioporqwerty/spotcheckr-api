using HotChocolate.Types;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types
{
	public class CertificateInputType : InputObjectType<Certificate>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Certificate> descriptor)
		{
			descriptor.Field(field => field.OrganizationId).Ignore();
		}
	}
}
