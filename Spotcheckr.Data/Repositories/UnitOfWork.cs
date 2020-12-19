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

		public UnitOfWork(SpotcheckrCoreContext context)
		{
			_context = context;

			Users = new UserRepository(_context);
			ExercisePosts = new ExercisePostRepository(_context);
			Emails = new EmailRepository(_context);
			PhoneNumbers = new PhoneNumberRepository(_context);
			Certifications = new CertificationRepository(_context);
			Certificates = new CertificateRepository(_context);
			Organizations = new OrganizationRepository(_context);
		}

		public void Dispose() => _context.Dispose();

		public int Complete() => _context.SaveChanges();
	}
}
