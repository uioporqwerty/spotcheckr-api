using System;
using System.Collections.Generic;

namespace Spotcheckr.Domain
{
	public class ExercisePost : IEntityTracking
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public int CreatedById { get; set; }

		public User CreatedBy { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }

		public ICollection<Media> Media { get; set; }
	}
}
