using System.Threading.Tasks;
using AutoMapper;
using Spotcheckr.API.Data.Repositories;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.Services
{
	public class ExercisePostService : IExercisePostService
	{
		private readonly IMapper Mapper;

		private readonly IUnitOfWork UnitOfWork;

		public ExercisePostService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			UnitOfWork = unitOfWork;
			Mapper = mapper;
		}

		public Task<ExercisePost> GetExercisePost(int id)
		{
			var post = UnitOfWork.ExercisePosts.GetExercisePostDetails(id);
			return Task.FromResult(Mapper.Map<ExercisePost>(post.Result));
		}
	}
}
