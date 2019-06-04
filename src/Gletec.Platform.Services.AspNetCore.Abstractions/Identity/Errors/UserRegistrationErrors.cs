using System;
using System.Collections.Generic;
using System.Text;

namespace Gletec.Platform.Services.AspNetCore.Abstractions.Identity.Errors
{
	public enum UserRegistrationErrors
	{
		DefaultError					= 0b0000_0000_0000_0000_0000_0001,
		ConcurrencyFailure				= 0b0000_0000_0000_0000_0000_0010,
		PasswordMismatch				= 0b0000_0000_0000_0000_0000_0100,
		InvalidToken					= 0b0000_0000_0000_0000_0000_1000,
		LoginAlreadyAssociated			= 0b0000_0000_0000_0000_0001_0000,
		InvalidUserName					= 0b0000_0000_0000_0000_0010_0000,
		InvalidEmail					= 0b0000_0000_0000_0000_0100_0000,
		DuplicateUserName				= 0b0000_0000_0000_0000_1000_0000,
		DuplicateEmail					= 0b0000_0000_0000_0001_0000_0000,
		InvalidRoleName					= 0b0000_0000_0000_0010_0000_0000,
		DuplicateRoleName				= 0b0000_0000_0000_0100_0000_0000,
		UserAlreadyHasPassword			= 0b0000_0000_0000_1000_0000_0000,
		UserLockoutNotEnabled			= 0b0000_0000_0001_0000_0000_0000,
		UserAlreadyInRole				= 0b0000_0000_0010_0000_0000_0000,
		UserNotInRole					= 0b0000_0000_0100_0000_0000_0000,
		PasswordTooShort				= 0b0000_0000_1000_0000_0000_0000,
		PasswordRequiresNonAlphanumeric = 0b0000_0001_0000_0000_0000_0000,
		PasswordRequiresDigit			= 0b0000_0010_0000_0000_0000_0000,
		PasswordRequiresLower			= 0b0000_0100_0000_0000_0000_0000,
		PasswordRequiresUpper			= 0b0000_1000_0000_0000_0000_0000,
		RequireNotEnoughParameters		= 0b0001_0000_0000_0000_0000_0000,
	}
}
