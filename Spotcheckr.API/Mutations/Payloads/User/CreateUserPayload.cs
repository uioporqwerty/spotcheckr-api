using Spotcheckr.Domain;

namespace Spotcheckr.API.Mutations.Payloads
{
	public class CreateUserPayload
	{
		public CreateUserPayload(IUser user)
		{
			User = user;
		}

		public IUser User { get; }
	}
}