using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gletec.Platform.Services.AspNetCore.Abstractions.Extensions
{
	public static class TextExtensions
	{
		public static string SnakeToUpperCamel(this string self)
		{
			if (string.IsNullOrEmpty(self)) return self;

			return self.ToLower()
				.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1))
				.Aggregate(string.Empty, (s1, s2) => s1 + s2);
		}

		public static string ToSnakeUpperCase(this string pascalCase)
		{
			//if (CompiledRegex == null)
			//	CompiledRegex = new Regex(@"((?<=.)[A-Z][a-zA-Z]*)|((?<=[a-zA-Z])\d+)", RegexOptions.Compiled);

			//return CompiledRegex.Replace(pascalCase, @"_$1$2").ToUpper();

			return string.Concat(pascalCase.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToUpper();
		}
	}
}
