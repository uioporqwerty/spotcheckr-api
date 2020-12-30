using System;
using System.Collections.Generic;

namespace Spotcheckr.API.Models
{
	/// <summary>
	/// An exercise post represents an athlete post a user would like information about.
	/// </summary>
	public class ExercisePost
	{
		/// <summary>
		/// Unique identifier for the exercise post.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Title of the exercise post.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Detailed description of the exercise post.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Date the exercise post was modified. Defaults to Date Created when unmodified. 
		/// </summary>
		public DateTime ModifiedDate { get; set; }

		/// <summary>
		/// Date exercise post created.
		/// </summary>
		public DateTime CreatedDate { get; set; }

		/// <summary>
		/// User that created the exercise post.
		/// </summary>
		public IUser CreatedBy { get; set; }

		/// <summary>
		/// Comments related to the exercise post.
		/// </summary>
		public IEnumerable<Comment> Comments { get; set; }
	}
}
