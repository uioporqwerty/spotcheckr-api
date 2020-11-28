using Spotcheckr.API.Data;

namespace Spotcheckr.API.Repositories.Post
{
	public class ExercisePostRepository : Repository<ExercisePost>, IExercisePostRepository
	{
		public ExercisePostRepository(SpotcheckrCoreContext context) : base(context) { }
	}
}
