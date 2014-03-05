using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Core.ViewModels;

namespace Contacts.Core
{
	public class App : MvxApplication
	{
		public App()
		{
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<ContactsListViewModel>());
		}
	}
}
