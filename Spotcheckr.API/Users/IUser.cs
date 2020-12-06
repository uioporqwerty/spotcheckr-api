using HotChocolate.Types;
using Spotcheckr.Domain.Identifiers;

namespace Spotcheckr.API.Users
{
	[InterfaceType(Name = "User")]
	public interface IUser
	{
		public UserID ID { get; }

		public string? Username { get; }
	}
}
