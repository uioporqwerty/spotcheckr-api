﻿using System.Collections.Generic;
using HotChocolate.Types.Relay;
using Spotcheckr.API.Models;

namespace Spotcheckr.API.Mutations.Inputs
{
	public record UpdateUserContactInformationInput([ID] int Id,
													 IReadOnlyList<Email> EmailAddresses,
													 IReadOnlyList<PhoneNumber> PhoneNumbers);
}
