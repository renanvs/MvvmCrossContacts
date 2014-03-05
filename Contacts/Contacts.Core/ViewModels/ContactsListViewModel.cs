using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using Contacts.Core.Models;
using Contacts.Core.Services;

namespace Contacts.Core.ViewModels
{
	public class ContactsListViewModel : MvxViewModel
	{
		private ContactsService contactServiceInstance = ContactsService.Instance;
		
		public List<ContactsModel> ListContatos
		{
			get
			{
				//RaisePropertyChanged(() => ListContatos);
				return contactServiceInstance.GetAllContacts();
				
			}
		}
	}
}
