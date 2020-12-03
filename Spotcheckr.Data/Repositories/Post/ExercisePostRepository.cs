using Spotcheckr.Domain;

namespace Spotcheckr.Data.Repositories
{
	public class ExercisePostRepository : Repository<ExercisePost>, IExercisePostRepository
	{
		public ExercisePostRepository(SpotcheckrCoreContext context) : base(context) { }
	}
}
