using SubSonic.Core.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SubSonic.Core
{
	public static partial class Utilities
	{
		private static readonly Regex s_frameworkRegex = new Regex("(?<framework>[a-z]*)(?<major>[0-9]*).(?<minor>[0-9]*)", RegexOptions.Compiled);

		public static string FindHighestVersionedDirectory(string parentFolder, Func<string, bool> validate)
		{
			string bestMatch = null;
			var bestVersion = SemVersion.Zero;
			foreach (var dir in Directory.EnumerateDirectories(parentFolder))
			{
				var name = Path.GetFileName(dir);
				if (SemVersion.TryParse(name, out var version) && version.Major >= 0)
				{
					if (version > bestVersion && (validate == null || validate(dir)))
					{
						bestVersion = version;
						bestMatch = dir;
					}
				}
			}
			return bestMatch;
		}

		public static decimal GetNetStandardVersion(string framework)
		{
			var match = s_frameworkRegex.Match(framework);

			if (match.Groups["framework"].Value == "netcoreapp")
			{
				int.TryParse(match.Groups["major"].Value, out int major);

				if (major >= 3)
				{
					return 2.1M;
				}
			}
			return 2.0M;
		}
	}
}
