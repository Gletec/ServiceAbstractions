using Gletec.Platform.Services.AspNetCore.Abstractions.Identity.Errors;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Gletec.Platform.Services.AspNetCore.Abstractions.Identity.ViewModels
{
	/// <summary>
	/// 認可済みJWT情報を表します。
	/// </summary>
	[DataContract]
	public class AuthorizeJwtViewModel
	{
		/// <summary>
		/// アクセストークンを取得または設定します。
		/// </summary>
		[DataMember]
		public string AccessToken { get; set; }

		/// <summary>
		/// アクセストークンの有効期限を取得または設定します。
		/// </summary>
		[DataMember]
		public DateTime Expires { get; set; }
	}
}
