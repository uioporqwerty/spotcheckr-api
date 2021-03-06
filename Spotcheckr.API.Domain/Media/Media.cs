﻿using System;

namespace Spotcheckr.API.Domain
{
	public class Media : IEntityTracking
	{
		public int Id { get; set; }

		public int? ExercisePostId { get; set; }

		public ExercisePost ExercisePost { get; set; }

		public int? CommentId { get; set; }

		public Comment Comment { get; set; }

		public string URL { get; set; }

		public MediaType Type { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}
