using HotChocolate.Types;
using Spotcheckr.API.Models;
using Spotcheckr.API.Services;

namespace Spotcheckr.API.Types
{
	public class ExercisePostType : ObjectType<ExercisePost>
	{
		protected override void Configure(IObjectTypeDescriptor<ExercisePost> descriptor)
		{
			descriptor.Field(field => field.Id).ID(nameof(ExercisePost));
			descriptor.ImplementsNode()
				.IdField(field => field.Id)
				.ResolveNode(async (resolver, id) =>
				{
					var exercisePostService = resolver.Service<IExercisePostService>();
					return await exercisePostService.GetExercisePost(id);
				});
		}
	}
}
