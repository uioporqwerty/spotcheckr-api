using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spotcheckr.API.Domain;

namespace Spotcheckr.API.Data.Repositories
{
	public class ExercisePostRepository : Repository<ExercisePost>, IExercisePostRepository
	{
		public ExercisePostRepository(SpotcheckrCoreContext context) : base(context) { }

		public Task<ExercisePost> GetExercisePostDetails(int id) => Task.FromResult(Context.ExercisePosts.Where(post => post.Id == id)
										.Include(post => post.CreatedBy)
										.FirstOrDefault());
	}
}
