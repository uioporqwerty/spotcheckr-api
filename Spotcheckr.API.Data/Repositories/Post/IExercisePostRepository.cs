using System.Threading.Tasks;
using Spotcheckr.API.Domain;

namespace Spotcheckr.API.Data.Repositories
{
	public interface IExercisePostRepository : IRepository<ExercisePost>
	{
		public Task<ExercisePost> GetExercisePostDetails(int id);
	}
}
