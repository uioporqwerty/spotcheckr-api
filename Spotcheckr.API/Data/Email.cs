using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Spotcheckr.API.Data
{
	public class Email : IEntityTracking
	{
		public int Id { get; set; }

		[MaxLength(254)]
		public string Address { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}
