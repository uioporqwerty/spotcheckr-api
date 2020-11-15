﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Spotcheckr.API.Data
{
	public class PhoneNumber : IEntityTracking
	{
		public User User { get; set; }

		public int UserId { get; set; }

		[MaxLength(15)]
		public string Number { get; set; }

		[MaxLength(11)]
		public string Extension { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}
