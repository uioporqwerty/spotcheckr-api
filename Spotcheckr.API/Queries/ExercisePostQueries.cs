using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Spotcheckr.API.Models;
using Spotcheckr.API.Services;

namespace Spotcheckr.API.Queries
{
	[ExtendObjectType(Name = "Query")]
	public class ExercisePostQueries
	{
		/// <summary>
		/// Get exercise post details.
		/// </summary>
		/// <param name="exercisePostId"></param>
		/// <param name="exercisePostService"></param>
		/// <returns></returns>
		public async Task<ExercisePost> GetExercisePostAsync([ID(nameof(ExercisePost))] int id,
															 [Service] IExercisePostService exercisePostService) => await exercisePostService.GetExercisePost(id);
	}
}
