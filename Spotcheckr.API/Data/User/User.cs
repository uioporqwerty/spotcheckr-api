﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotcheckr.API.Data
{
	public class User : IEntityTracking
	{
		public int Id { get; set; }

		public UserType Type { get; set; }

		[MaxLength(50)]
		public string FirstName { get; set; }

		[MaxLength(50)]
		public string? MiddleName { get; set; }

		[MaxLength(50)]
		public string LastName { get; set; }

		[MaxLength(50)]
		public string? Username { get; set; }

		public string? Website { get; set; }

		public string? ProfilePictureUrl { get; set; }

		public DateTime? BirthDate { get; set; }

		[Column(TypeName = "decimal(6, 2)")]
		public decimal? Height { get; set; }

		[Column(TypeName = "decimal(5, 2)")]
		public decimal? Weight { get; set; }

		public string? Occupation { get; set; }

		public Company? Company { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }

		public ICollection<Email> Emails { get; set; }

		public ICollection<PhoneNumber> PhoneNumbers { get; set; }

		public ICollection<Certification> Certifications { get; set; }
	}
}