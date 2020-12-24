namespace Spotcheckr.Data.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SpotcheckrCoreContext _context;

		public IUserRepository Users { get; }

		public IExercisePostRepository ExercisePosts { get; }

		public IEmailRepository Emails { get; }

		public IPhoneNumberRepository PhoneNumbers { get; }

		public ICertificationRepository Certifications { get; }

		public IOrganizationRepository Organizations { get; }

		public ICertificateRepository Certificates { get; }

		public UnitOfWork(SpotcheckrCoreContext context,
						  IUserRepository userRepository,
						  IExercisePostRepository exercisePostRepository,
						  IEmailRepository emailRepository,
						  IPhoneNumberRepository phoneNumberRepository,
						  ICertificationRepository certificationRepository,
						  ICertificateRepository certificateRepository,
						  IOrganizationRepository organizationRepository)
		{
			_context = context;

			Users = userRepository;
			ExercisePosts = exercisePostRepository;
			Emails = emailRepository;
			PhoneNumbers = phoneNumberRepository;
			Certifications = certificationRepository;
			Certificates = certificateRepository;
			Organizations = organizationRepository;
		}

		public void Dispose() => _context.Dispose();

		public int Complete() => _context.SaveChanges();
	}
}
