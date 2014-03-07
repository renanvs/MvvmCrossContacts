using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.ViewModels;
using Contacts.Core.Models;
using Contacts.Core.Services;

namespace Contacts.Android.Linked.ViewModels
{
	public class ContatosFormViewModel : MvxViewModel
	{
		private readonly IContactsService _contactsService;
		/// <summary>
		/// Ao criar o ViewModel (apenas uma vez), é criado alguns contatos de teste e enviado para a lista
		/// </summary>
		/// <param name="contactsService"></param>
		public ContatosFormViewModel(IContactsService contactsService) {
			_contactsService = contactsService;

		}

		public string Name { get; set; }
		public string LastName { get; set; }
		public string Telephone { get; set; }
		public string Mail { get; set; }

		public void AddContato() {
			var model = new ContactsModel(Name, LastName, Telephone, Mail);
			_contactsService.AddContact(model);
		}
	}
}