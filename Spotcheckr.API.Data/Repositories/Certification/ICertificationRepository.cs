using System.Threading.Tasks;
using Spotcheckr.API.Domain;

namespace Spotcheckr.API.Data.Repositories
{
	public interface ICertificationRepository : IRepository<Certification>
	{
		public Task<Certification> GetCertificationDetails(int certificationId);
	}
}
