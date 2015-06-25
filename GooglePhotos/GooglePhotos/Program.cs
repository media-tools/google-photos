using System;
using Core.Common;
using Core.Google.Auth;
using Core.Platform;
using Core.Portable;

namespace GooglePhotos
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
			DesktopPlatform.Start ();

			GoogleApp.Secrets = new GoogleApp.ClientSecretsJson () {
				ClientId = "574696664370-fjvhqijeokikvqblaqmf30hpk9g280r4.apps.googleusercontent.com",
				ClientSecret = "6RPbdpnnaCDgJr3iNTmpgmjT",
			};
			GoogleAccount.CONFIG_PATH = PlatformInfo.User.HomeDirectory + "/.config/control/config/Google/accounts.json";

			auth ();

			DesktopPlatform.Finish ();
		}

		static void auth ()
		{
			GoogleApp appConfig = new GoogleApp ();
			foreach (GoogleAccount acc in GoogleAccount.List()) {
				Log.Info ("Google Account: ", acc);
				Log.Indent++;
				if (appConfig.Authenticate (acc)) {
					Log.Info ("Success!");
				} else {
					Log.Info ("Failure!");
				}
				Log.Indent--;
			}
		}
	}
}

