using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotcheckr.API.Data
{
	[Table("ExercisePosts")]
	public class ExercisePost : IEntityTracking
	{
		public int Id { get; set; }

		[MaxLength(1000)]
		public string Title { get; set; }

		[MaxLength(10000)]
		public string Description { get; set; }

		public int CreatedById { get; set; }

		public User CreatedBy { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }

		public ICollection<Media> Media { get; set; }
	}
}
