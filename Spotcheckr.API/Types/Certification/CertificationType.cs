using HotChocolate.Types;
using Spotcheckr.Models;

namespace Spotcheckr.API.Types
{
	public class CertificationType : ObjectType<Certification>
	{
		protected override void Configure(IObjectTypeDescriptor<Certification> descriptor)
		{
		}
	}
}
