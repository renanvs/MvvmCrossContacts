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
	}
}
