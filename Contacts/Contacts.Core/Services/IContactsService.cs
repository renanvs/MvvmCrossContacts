using System.Collections.Generic;
using Contacts.Core.Models;

namespace Contacts.Core.Services
{
	public interface IContactsService
	{
		void AddContact(ContactsModel ContactModel);
		List<ContactsModel> GetAllContacts();
		ContactsModel GetContactModelWithId(string objectId);
		void UpdateContact(ContactsModel model);
	}
}