using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace Spotcheckr.API.Data
{
	public static class DatabaseInitializer
	{
		private static SpotcheckrCoreContext _context = default!;
		
		public static void Initialize(SpotcheckrCoreContext context)
		{
			_context = context;
			
			_context.Database.EnsureCreated();

			if (DatabaseHasData)
			{
				return;
			}

			_context.AddRange(TestOrganizations);
			_context.SaveChanges();

			var issuingOrganization = _context.Organizations.First();

			var certificates = TestCertificates.ToList();
			certificates.ForEach(cert => cert.Organization = issuingOrganization);

			_context.AddRange(certificates);
			_context.SaveChanges();

			var users = CreateTestUsers(5);
			_context.AddRange(users);
			_context.SaveChanges();

			var exercisePosts = CreateTestExercisePosts(20);
			_context.AddRange(exercisePosts);
			_context.SaveChanges();

			var exercisePostComments = CreateTestExercisePostComments(20);
			_context.AddRange(exercisePostComments);
			_context.SaveChanges();

			var exercisePostMedia = CreateTestMedia(true,5);
			var commentMedia = CreateTestMedia(false, 5);
			_context.AddRange(exercisePostMedia);
			_context.AddRange(commentMedia);
			_context.SaveChanges();
		}

		private static IEnumerable<Media> CreateTestMedia(bool isExercisePost, int count)
		{
			var media = new Faker<Media>()
				.RuleFor(field => field.URL, fake => fake.Image.LoremFlickrUrl())
				.RuleFor(field => field.Type, fake => MediaType.Picture);

			if (isExercisePost)
			{
				media.RuleFor(field => field.ExercisePost, fake => fake.PickRandom(_context.ExercisePosts.ToList()));
			}
			else
			{
				media.RuleFor(field => field.Comment, fake => fake.PickRandom(_context.Comments.ToList()));
			}

			return media.Generate(count);
		}

		private static IEnumerable<Comment> CreateTestExercisePostComments(int count)
		{
			var refDateCreated = DateTime.Now;

			var comments = new Faker<Comment>()
				.RuleFor(field => field.Text, fake => fake.Lorem.Paragraphs(fake.PickRandom(1, 2, 3)))
				.RuleFor(field => field.DateCreated, fake =>
				{
					refDateCreated = fake.Date.RecentOffset(365).DateTime;
					return refDateCreated;
				})
				.RuleFor(field => field.DateModified, fake => fake.Date.Between(refDateCreated, DateTime.Now))
				.RuleFor(field => field.ExercisePost, fake => fake.PickRandom(_context.ExercisePosts.ToList()));

			return comments.Generate(count);
		}

		private static IEnumerable<ExercisePost> CreateTestExercisePosts(int count)
		{
			var refDateCreated = DateTime.Now;

			var exercisePosts = new Faker<ExercisePost>()
				.RuleFor(field => field.Title, fake => fake.Lorem.Lines(1))
				.RuleFor(field => field.Description, fake => fake.Lorem.Paragraphs(fake.PickRandom(1, 2, 3, 4)))
				.RuleFor(field => field.DateCreated, fake =>
				{
					refDateCreated = fake.Date.RecentOffset(365).DateTime;
					return refDateCreated;
				})
				.RuleFor(field => field.DateModified, fake => fake.Date.Between(refDateCreated, DateTime.Now))
				.RuleFor(field => field.CreatedBy, fake => fake.PickRandom(_context.Users.ToList()));

			return exercisePosts.Generate(count);
		}

		private static bool DatabaseHasData => _context.Users.Any();

		private static IEnumerable<Certificate> TestCertificates => new List<Certificate>
		{
			new Certificate { Code = "NASM-CPT", Description = "Certified Personal Trainer" },
			new Certificate { Code = "NASM-CNC", Description = "Nutrition Certification" },
			new Certificate { Code = "NASM-CES", Description = "Corrective Exercise Specialization" },
			new Certificate { Code = "NASM-PES", Description = "Performance Enhancement Specialization" },
			new Certificate { Code = "NASM-VCS", Description = "Virtual Coaching Specialization" },
			new Certificate { Code = "NASM-WLS", Description = "Weight Loss Specialization" },
			new Certificate { Code = "NASM-GPTS", Description = "Group Personal Training Specialization Program" },
			new Certificate { Code = "NASM-YES", Description = "Youth Exercise Specialization" }
		};

		private static IEnumerable<Organization> TestOrganizations => new List<Organization>
		{
			new Organization { Name = "National Academy of Sports Medicine", Abbreviation = "NASM" }
		};

		private static IEnumerable<User> CreateTestUsers(int count)
		{
			var refDateCreated = DateTime.Now;
			var refUserType = UserType.Athlete;

			var users = new Faker<User>()
				.RuleFor(field => field.Type, fake =>
				{
					refUserType = fake.PickRandom<UserType>();
					return refUserType;
				})
				.RuleFor(field => field.FirstName, fake => fake.Name.FirstName())
				.RuleFor(field => field.MiddleName, fake => fake.Name.FirstName())
				.RuleFor(field => field.LastName, fake => fake.Name.LastName())
				.RuleFor(field => field.Username, fake => fake.Internet.UserName())
				.RuleFor(field => field.Website, fake => fake.Person.Website)
				.RuleFor(field => field.ProfilePictureUrl, fake => fake.Internet.Avatar())
				.RuleFor(field => field.BirthDate, fake => fake.Person.DateOfBirth)
				.RuleFor(field => field.Height, fake => Math.Round(fake.Random.Decimal(1200, 2700), 2))
				.RuleFor(field => field.Weight, fake => Math.Round(fake.Random.Decimal(70, 500), 2))
				.RuleFor(field => field.Occupation, fake => fake.Name.JobTitle())
				.RuleFor(field => field.DateCreated, fake =>
				{
					refDateCreated = fake.Date.RecentOffset(365).DateTime;
					return refDateCreated;
				})
				.RuleFor(field => field.DateModified, fake => fake.Date.Between(refDateCreated, DateTime.Now))
				.RuleFor(field => field.Emails, fake => CreateTestEmails(3))
				.RuleFor(field => field.PhoneNumbers, fake => CreateTestPhoneNumbers(1))
				.RuleFor(field => field.Certifications, fake =>
				{
					return refUserType switch
					{
						UserType.PersonalTrainer => CreateTestCertifications(3),
						_ => null,
					};
				})
				.RuleFor(field => field.Company, fake =>
				{
					return refUserType switch
					{
						UserType.PersonalTrainer => CreateTestCompany(),
						_ => null
					};
				});

			return users.Generate(count);
		}

		private static Company CreateTestCompany() => new Faker<Company>()
													 .RuleFor(field => field.Name, fake => fake.Company.CompanyName())
													 .Generate(1)
													 .First();
		
		private static IEnumerable<Certification> CreateTestCertifications(int count)
		{
			var refDateCreated = DateTime.Now;

			var certifications = new Faker<Certification>()
				.RuleFor(field => field.DateCreated, fake =>
				{
					refDateCreated = fake.Date.RecentOffset(365).DateTime;
					return refDateCreated;
				})
				.RuleFor(field => field.DateModified, fake => fake.Date.Between(refDateCreated, DateTime.Now))
				.RuleFor(field => field.DateAchieved, fake => fake.Date.Past(15, DateTime.Now))
				.RuleFor(field => field.Verified, fake => fake.PickRandom(true, false))
				.RuleFor(field => field.Number, fake => fake.PickRandom(fake.Random.AlphaNumeric(8)))
				.RuleFor(field => field.Certificate, fake =>fake.PickRandom(_context.Certificates.ToList()));

			return certifications.Generate(count);
		}

		private static IEnumerable<Email> CreateTestEmails(int count)
		{
			var refDateCreated = DateTime.Now;

			var emails = new Faker<Email>()
				.RuleFor(field => field.Address, fake => fake.Internet.Email())
				.RuleFor(field => field.DateCreated, fake =>
				{
					refDateCreated = fake.Date.RecentOffset(365).DateTime;
					return refDateCreated;
				})
				.RuleFor(field => field.DateModified, fake => fake.Date.Between(refDateCreated, DateTime.Now));

			return emails.Generate(count);
		}

		private static IEnumerable<PhoneNumber> CreateTestPhoneNumbers(int count)
		{
			var refDateCreated = DateTime.Now;

			var phoneNumbers = new Faker<PhoneNumber>()
				.RuleFor(field => field.Number, fake => fake.Phone.PhoneNumber("###-###-####"))
				.RuleFor(field => field.DateCreated, fake =>
				{
					refDateCreated = fake.Date.RecentOffset(365).DateTime;
					return refDateCreated;
				})
				.RuleFor(field => field.DateModified, fake => fake.Date.Between(refDateCreated, DateTime.Now));

			return phoneNumbers.Generate(count);
		}
	}
}
