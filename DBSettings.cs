using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DropBoxWatcher
{
	public static class DBSettings
	{
		public static string DBPublicPath
		{
			get { return DropBoxWatcher.Properties.Settings.Default.DropBoxPublicFolder; }
			set
			{
				if (value.EndsWith(@"\"))
				{
					value = value.Substring(0, value.Length - 1);
				}
				DropBoxWatcher.Properties.Settings.Default.DropBoxPublicFolder = value;
				DropBoxWatcher.Properties.Settings.Default.Save();
			}
		}

		public static string PublicURL
		{
			get { return DropBoxWatcher.Properties.Settings.Default.PublicURL; }
			set
			{
				if (!value.EndsWith("/"))
				{
					value += "/";
				}
				DropBoxWatcher.Properties.Settings.Default.PublicURL = value;
				DropBoxWatcher.Properties.Settings.Default.Save();
			}
		}
	}
}
