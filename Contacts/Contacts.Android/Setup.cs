using Android.Content;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Contacts.Core;
using Contacts.Core.IO;
using SqlSample.Droid.IO;

namespace Contacts.Android
{
	class Setup :MvxAndroidSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{
			
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override IMvxNavigationSerializer CreateNavigationSerializer()
		{
			Cirrious.MvvmCross.Plugins.Json.PluginLoader.Instance.EnsureLoaded();
			Cirrious.MvvmCross.Plugins.Messenger.PluginLoader.Instance.EnsureLoaded();
			return new MvxJsonNavigationSerializer();
		}

		protected override void InitializeLastChance()
		{
			base.InitializeLastChance();
			Mvx.RegisterType(typeof(IDeviceFileSystem), typeof(DroidDeviceFileSystem));
		}
	}
}