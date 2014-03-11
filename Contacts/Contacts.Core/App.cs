using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Contacts.Android.Linked.ViewModels;
using Contacts.Core.Services;
using Contacts.Core.ViewModels;
using SqlSample.Core.Services;

namespace Contacts.Core
{
	public class App : MvxApplication
	{
		public App()
		{
			Mvx.RegisterType<IContactsService, ContactsService>();
			Mvx.RegisterType<IDataBaseService, DataBaseService>();
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<ContactsListViewModel>());
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<ContatosFormViewModel>());
		}
	}
}
