using System;

namespace Spotcheckr.API.Data.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository Users { get; }

		IExercisePostRepository ExercisePosts { get; }

		IEmailRepository Emails { get; }

		IPhoneNumberRepository PhoneNumbers { get; }

		ICertificationRepository Certifications { get; }

		IOrganizationRepository Organizations { get; }

		ICertificateRepository Certificates { get; }

		int Complete();
	}
}
