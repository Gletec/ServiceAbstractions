using Gletec.Platform.Services.AspNetCore.Abstractions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Gletec.Platform.Services.AspNetCore.Abstractions
{
	public class Meta
	{
		public HttpStatusCode Code { get; set; }

		public string ErrorCode { get; set; }

		public bool TryExtractCodes<T>(out IEnumerable<(T code, string options)> codes)
			where T : struct
			=> TryExtractCodes(ErrorCode, out codes);

		public bool TryExtractCodes<T>(string raw, out IEnumerable<(T code, string options)> codes)
			where T : struct
		{
			var splitted = raw.Split('+');
			codes = splitted
				.Select(s => ExtractUnitErrorCode<T>(s))
				.Where(u => u.code != null)
				.Select(u => (u.code.Value, u.options)).ToArray();

			return codes.Any();
		}

		private (T? code, string options) ExtractUnitErrorCode<T>(string raw)
			where T : struct
		{
			var splitted = raw.Split(':');

			var rawCode = splitted[0];

			if (!Enum.TryParse<T>(rawCode.SnakeToUpperCamel(), out var errorCode))
				return (null, splitted.Count() > 1 ? splitted[1] : null);

			return (errorCode, splitted.Count() > 1 ? splitted[1] : null);
		}
	}
}
