using Gletec.Platform.Services.AspNetCore.Abstractions.Identity.Errors;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gletec.Platform.Services.AspNetCore.Abstractions.Identity.Filters
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class AuthorizeApiAttribute : ActionFilterAttribute
	{
		public AuthorizeApiAttribute()
		{
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			switch (context.HttpContext.User.Identity.AuthenticationType)
			{
				case "AuthenticationTypes.Federation":
					base.OnActionExecuting(context);
					return;
			}

			// Authorizationヘッダがあるのにここまで認証が終わってなければ認証失敗したということ
			if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
			{
				context.Result = ApiResponse.Create()
					.SetErrorCodes(AuthenticateErrors.InvalidToken)
					.WithUnAuthorized();

				base.OnActionExecuting(context);
				return;
			}

			// そもそもトークン付いてなかったら付けるように促す
			context.Result = ApiResponse.Create()
					.SetErrorCodes(AuthenticateErrors.RequireToken)
					.WithUnAuthorized();

			base.OnActionExecuting(context);
		}
	}
}
