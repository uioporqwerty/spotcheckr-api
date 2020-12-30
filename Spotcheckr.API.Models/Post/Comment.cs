using System;

namespace Spotcheckr.API.Models
{
	/// <summary>
	/// Represents responses by users on an exercise post.
	/// </summary>
	public class Comment
	{
		/// <summary>
		/// Text of the comment.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Date comment was modified. Defaults to created date if unmodified.
		/// </summary>
		public DateTime ModifiedDate { get; set; }

		/// <summary>
		/// Date comment was created.
		/// </summary>
		public DateTime CreatedDate { get; set; }

		/// <summary>
		/// User that created the comment.
		/// </summary>
		public IUser CreatedBy { get; set; }
	}
}
