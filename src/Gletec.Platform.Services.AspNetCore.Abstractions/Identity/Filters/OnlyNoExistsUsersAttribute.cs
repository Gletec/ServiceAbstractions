using Gletec.Platform.Services.AspNetCore.Abstractions.Identity.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gletec.Platform.Services.AspNetCore.Abstractions.Identity.Filters
{
	public class OnlyNoExistsUsersAttribute : ActionFilterAttribute
	{
		private UserManager<IdentityUser> UserManager { get; }

		public OnlyNoExistsUsersAttribute(UserManager<IdentityUser> userManager)
		{
			UserManager = userManager;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (!UserManager.Users.Any())
			{
				base.OnActionExecuting(context);
				return;
			}

			context.Result = ApiResponse.Create()
					.SetErrorCodes(AuthenticateErrors.OnlyExecuteFirstStep)
					.WithNotAcceptable();
		}
	}
}
