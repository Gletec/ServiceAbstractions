﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gletec.Platform.Services.AspNetCore.Abstractions.Identity.ViewModels
{
	public class SignInViewModel
	{
		public string Email { get; set; }

		public string Password { get; set; }
	}
}
