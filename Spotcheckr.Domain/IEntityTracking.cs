using System;

namespace Spotcheckr.Domain
{
	public interface IEntityTracking
	{
		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}
