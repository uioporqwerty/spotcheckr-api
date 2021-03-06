﻿using AutoMapper;
using Spotcheckr.API.Mutations.Inputs;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.AutoMapper
{
	public class AutoMapperConfigurationProfile : Profile
	{
		public AutoMapperConfigurationProfile()
		{
			CreateMap<UpdateUserProfileInput, Athlete>();
			CreateMap<UpdateUserProfileInput, PersonalTrainer>();
			CreateMap<UpdateUserContactInformationInput, ContactInformation>();
			CreateMap<Domain.Organization, Organization>();
			CreateMap<Domain.Certificate, Certificate>();
			CreateMap<Domain.Certification, Certification>();
			CreateMap<Domain.User, Athlete>();
			CreateMap<Domain.User, PersonalTrainer>();
			CreateMap<Domain.User, IUser>().IncludeAllDerived();
			CreateMap<Domain.ExercisePost, ExercisePost>();
			CreateMap<Domain.UserType, UserType>();
		}
	}
}
