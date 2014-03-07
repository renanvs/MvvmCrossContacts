using System.Collections.Generic;
using Contacts.Core.Models;

namespace Contacts.Core.Services
{
	public class ContactsService : IContactsService
	{
		private static List<ContactsModel> contactList;

		/// <summary>
		/// Adiciona um novo contato para a lista, passando um model de contato
		/// </summary>
		/// <param name="ContactModel">Model do contato</param>
		public void AddContact(ContactsModel ContactModel)
		{
			if (contactList == null) {
				contactList = new List<ContactsModel>();
			}

			contactList.Add(ContactModel);
		}

		/// <summary>
		/// Retorna a lista de todos os contatos existentes no List
		/// </summary>
		/// <returns>List com todos os contatos</returns>
		public List<ContactsModel> GetAllContacts()
		{
			return contactList;
		}

		private static bool isFirstTime = true;
		public ContactsService()
		{
			if (!isFirstTime) {
				return;
			}
			var c1 = new ContactsModel("renan", "silva");
			var c2 = new ContactsModel("joao", "sub1");
			var c3 = new ContactsModel("maria", "sub2");
			AddContact(c1);
			AddContact(c2);
			AddContact(c3);
			isFirstTime = false;
		}
	}
}
