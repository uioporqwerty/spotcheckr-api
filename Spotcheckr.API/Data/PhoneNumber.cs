using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Spotcheckr.API.Data
{
	public class PhoneNumber : IEntityTracking
	{
		public int Id { get; set; }

		[MaxLength(15)]
		public string Number { get; set; }

		[MaxLength(11)]
		public string Extension { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}
