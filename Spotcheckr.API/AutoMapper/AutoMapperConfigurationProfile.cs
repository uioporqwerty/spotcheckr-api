using AutoMapper;
using Spotcheckr.API.Mutations.Inputs;
using Spotcheckr.Domain;

namespace Spotcheckr.API.AutoMapper
{
	public class AutoMapperConfigurationProfile : Profile
	{
		public AutoMapperConfigurationProfile()
		{
			CreateMap<UpdateUserProfileInput, Athlete>();
			CreateMap<UpdateUserProfileInput, PersonalTrainer>();
			CreateMap<UpdateUserContactInformationInput, ContactInformation>();
		}
	}
}
