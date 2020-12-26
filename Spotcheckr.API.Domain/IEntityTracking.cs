using System;

namespace Spotcheckr.API.Domain
{
	public interface IEntityTracking
	{
		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}
