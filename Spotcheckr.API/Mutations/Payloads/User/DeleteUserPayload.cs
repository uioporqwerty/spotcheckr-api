namespace Spotcheckr.API.Mutations.Payloads
{
	public class DeleteUserPayload
	{
		public DeleteUserPayload(int userId)
		{
			Id = userId;
		}

		public int Id { get; }
	}
}
