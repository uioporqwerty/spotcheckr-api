using Spotcheckr.Domain.Identifiers;

namespace Spotcheckr.API.Users
{
	public class PersonalTrainer : IUser
	{
		public PersonalTrainer(int id, string? username)
		{
			ID = new UserID(id);
			Username = username;
		}

		public UserID ID { get; }

		public string? Username { get; }
	}
}
