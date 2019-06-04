using System;
using System.Collections.Generic;
using System.Text;

namespace Gletec.Platform.Services.AspNetCore.Abstractions.Identity.Errors
{
	public enum AuthenticateErrors
	{
		InvalidToken			= 0b0000_0000_0001,
		RequireToken			= 0b0000_0000_0010,
		OnlyExecuteFirstStep	= 0b0000_0000_0100,
		MismatchCredentials		= 0b0000_0000_1000,
	}
}
