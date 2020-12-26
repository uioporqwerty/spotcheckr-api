using HotChocolate.Types;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.Types
{
	public class CertificateInputType : InputObjectType<Certificate>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Certificate> descriptor)
		{
		}
	}
}
