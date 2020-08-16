using SubSonic.Core.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SubSonic.Core
{
    public partial class Utilities
    {
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
	}
}
