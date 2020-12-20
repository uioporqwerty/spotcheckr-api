using System.Threading.Tasks;

namespace Spotcheckr.API.Services
{
	public interface ICertificationService
	{
		public Task<bool> ValidateCertificationAsync(int certificationId);

	}
}
