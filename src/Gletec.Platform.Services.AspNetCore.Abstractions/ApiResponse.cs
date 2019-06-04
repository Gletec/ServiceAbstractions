using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Gletec.Platform.Services.AspNetCore.Abstractions.Extensions;

namespace Gletec.Platform.Services.AspNetCore.Abstractions
{
	public class ApiResponse
	{
		public Meta Meta { get; set; } = new Meta();

		public static ApiResponse<TData> Create<TData>(TData data)
			=> new ApiResponse<TData>
			{
				Data = data
			};

		public static ApiResponse Create()
			=> new ApiResponse
			{

			};

		public ApiResponse SetErrorCodes<T>(T value)
			where T : struct
		{
			var flags = new List<string>();
			foreach (var flag in Enum.GetValues(typeof(T)))
			{
				if ((Convert.ToUInt64(value) & Convert.ToUInt64(flag)) == Convert.ToUInt64(flag))
					flags.Add(flag.ToString());
			}

			Meta.ErrorCode = string.Join("+", flags.Select(f => f.ToString().ToSnakeUpperCase()));

			return this;
		}

		public ApiResponse AddErrorCode<T>(T value, object region = null)
			where T : struct
		{
			if (region != null)
				Meta.ErrorCode = string.Join("+", Meta.ErrorCode, $"{value.ToString().ToSnakeUpperCase()}={region}");
			else
				Meta.ErrorCode = string.Join("+", Meta.ErrorCode, $"{value.ToString().ToSnakeUpperCase()}");

			return this;
		}

		public ObjectResult WithOk()
			=> GetObjectResult(HttpStatusCode.OK);

		public ObjectResult WithCreated()
			=> GetObjectResult(HttpStatusCode.Created);

		public ObjectResult WithUnAuthorized()
			=> GetObjectResult(HttpStatusCode.Unauthorized);

		public ObjectResult WithForbidden()
			=> GetObjectResult(HttpStatusCode.Forbidden);

		public ObjectResult WithNotAcceptable()
			=> GetObjectResult(HttpStatusCode.NotAcceptable);

		public ObjectResult WithBadRequest()
			=> GetObjectResult(HttpStatusCode.BadRequest);

		public ObjectResult WithNotImplemented()
			=> GetObjectResult(HttpStatusCode.NotImplemented);

		public ObjectResult WithInternalError()
			=> GetObjectResult(HttpStatusCode.InternalServerError);

		public ObjectResult WithNotFound()
			=> GetObjectResult(HttpStatusCode.NotFound);

		private ObjectResult GetObjectResult(HttpStatusCode code)
		{
			Meta.Code = code;
			return new ObjectResult(this) { StatusCode = (int)code };
		}
	}

	public class ApiResponse<TData> : ApiResponse
	{
		public TData Data { get; set; }

		public new ApiResponse<TData> SetErrorCodes<T>(T value)
			where T : struct
		{
			var flags = new List<string>();
			foreach (var flag in Enum.GetValues(typeof(T)))
			{
				if ((Convert.ToUInt64(value) & Convert.ToUInt64(flag)) == Convert.ToUInt64(flag))
					flags.Add(flag.ToString());
			}

			Meta.ErrorCode = string.Join("+", flags.ToString().ToSnakeUpperCase());

			return this;
		}

		public new ApiResponse<TData> AddErrorCode<T>(T value, object region)
			where T : struct
		{
			Meta.ErrorCode = string.Join("+", Meta.ErrorCode, $"{value.ToString().ToSnakeUpperCase()}={region}");

			return this;
		}
	}
}
