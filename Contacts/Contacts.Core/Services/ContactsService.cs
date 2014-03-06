using System.Collections.Generic;
using Contacts.Core.Models;

namespace Contacts.Core.Services
{
	public class ContactsService : IContactsService
	{
		private static List<ContactsModel> contactList;

		public void AddContact(ContactsModel ContactModel)
		{
			if (contactList == null) {
				contactList = new List<ContactsModel>();
			}

			contactList.Add(ContactModel);
		}

		public List<ContactsModel> GetAllContacts()
		{
			return contactList;
		} 
	}
}
