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
			var model = new ContactsModel();
			model.FirstName = Name;
			model.LastName = LastName;
			model.Telephone= Telephone;
			model.Mail = Mail;
			_contactsService.AddContact(model);
		}

		public void UpdateContato(string id)
		{
			var model = _contactsService.GetContactModelWithId(id);
			model.FirstName = Name;
			model.LastName = LastName;
			model.Telephone = Telephone;
			model.Mail = Mail;
			_contactsService.UpdateContact(model);
		}

		public void PopulateWithId(string objectId)
		{
			ContactsModel model = _contactsService.GetContactModelWithId(objectId);
			Name = model.FirstName;
			LastName = model.LastName;
			Telephone = model.Telephone;
			Mail = model.Mail;
		}
	}
}