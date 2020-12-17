﻿using HotChocolate.Types;
using Spotcheckr.Domain;

namespace Spotcheckr.API.Types.Contact
{
	public class PhoneNumberType : ObjectType<PhoneNumber>
	{
		protected override void Configure(IObjectTypeDescriptor<PhoneNumber> descriptor)
		{
			descriptor.Field(field => field.Id).ID(nameof(PhoneNumber));
			descriptor.Field(field => field.UserId).Ignore();
			descriptor.Field(field => field.User).Ignore();
			descriptor.Field(field => field.DateCreated).Ignore();
			descriptor.Field(field => field.DateModified).Ignore();
		}
	}
}
