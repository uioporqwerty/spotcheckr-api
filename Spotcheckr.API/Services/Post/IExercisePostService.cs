using System.Threading.Tasks;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.Services
{
	public interface IExercisePostService
	{
		public Task<ExercisePost> GetExercisePost(int id);
	}
}
