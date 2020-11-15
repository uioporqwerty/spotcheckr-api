using System;

namespace Spotcheckr.API.Data
{
	public interface IEntityTracking
	{
		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }
	}
}
