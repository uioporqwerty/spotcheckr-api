using System;
using System.Collections.Generic;

namespace Spotcheckr.Domain
{
	public class Comment : IEntityTracking
	{
		public int Id { get; set; }

		public string Text { get; set; }

		public int ExercisePostId { get; set; }

		public ExercisePost ExercisePost { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }

		public ICollection<Media> Media { get; set; }
	}
}
