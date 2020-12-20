using HotChocolate.Types;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types
{
	public class CertificationType : ObjectType<Certification>
	{
		protected override void Configure(IObjectTypeDescriptor<Certification> descriptor)
		{
			descriptor.Field(field => field.DateCreated).Ignore();
			descriptor.Field(field => field.DateModified).Ignore();
			descriptor.Field(field => field.UserId).Ignore();
			descriptor.Field(field => field.CertificateId).Ignore();
		}
	}
}
