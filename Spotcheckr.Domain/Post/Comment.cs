using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotcheckr.Domain
{
	[Table("Comments")]
	public class Comment : IEntityTracking
	{
		public int Id { get; set; }

		[MaxLength(10000)]
		public string Text { get; set; }

		public int ExercisePostId { get; set; }

		public ExercisePost ExercisePost { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }

		public ICollection<Media> Media { get; set; }
	}
}
