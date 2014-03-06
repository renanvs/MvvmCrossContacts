using System;
using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using Contacts.Core.Models;
using Contacts.Core.Services;

namespace Contacts.Core.ViewModels
{
	public class ContactsListViewModel : MvxViewModel
	{

		private readonly IContactsService _contactsService;
		
		public ContactsListViewModel(IContactsService contactsService)
		{
			_contactsService = contactsService;
			var c1 = new ContactsModel("renan", "silva");
			var c2 = new ContactsModel("joao", "sub1");
			var c3 = new ContactsModel("maria", "sub2");
			contactsService.AddContact(c1);
			contactsService.AddContact(c2);
			contactsService.AddContact(c3);
		}

		private string teste;

		public string Teste {
			get { return "teste123"; }
			set { teste = value; }
		}

		public List<ContactsModel> ListContatos
		{
			get
			{
				return _contactsService.GetAllContacts();
				
			}
		}

		public void AddContato(ContactsModel model)
		{
			_contactsService.AddContact(model);
			RaisePropertyChanged(()=>ListContatos);
		}

	}
}
