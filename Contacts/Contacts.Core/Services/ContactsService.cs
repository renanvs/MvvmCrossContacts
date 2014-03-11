using System;
using System.Collections.Generic;
using Contacts.Core.Models;
using SqlSample.Core.Services;

namespace Contacts.Core.Services
{
	public class ContactsService : IContactsService
	{
		//private static List<ContactsModel> contactList;

		/// <summary>
		/// Adiciona um novo contato para a lista, passando um model de contato
		/// </summary>
		/// <param name="ContactModel">Model do contato</param>
		public void AddContact(ContactsModel ContactModel)
		{
			/*if (contactList == null) {
				contactList = new List<ContactsModel>();
			}*/

			//ContactModel.IdContact = GetNewId();

			//contactList.Add(ContactModel);
			_dataService.insertContactInDb(ContactModel);
		}

		/*private string GetNewId()
		{
			int highestId = 0;
			foreach (var contactsModel in contactList) {
				int currentIdInt = Convert.ToInt32(contactsModel.IdContact);
				if (currentIdInt > highestId) {
					highestId = currentIdInt;
				}
			}
			return (highestId + 1).ToString();
		}*/

		public void UpdateContact(ContactsModel model)
		{
			_dataService.updateContentInDb(model);
		}

		/// <summary>
		/// Retorna a lista de todos os contatos existentes no List
		/// </summary>
		/// <returns>List com todos os contatos</returns>
		public List<ContactsModel> GetAllContacts()
		{
			return _dataService.getAllContacts();
		}

		public ContactsModel GetContactModelWithId(string objectId)
		{
			return _dataService.getModelWithId(objectId);
		}

		private readonly IDataBaseService _dataService;
		private static bool isFirstTime = true;
		public ContactsService(IDataBaseService dataService)
		{
			_dataService = dataService;
			
			if (_dataService.hasSample()) {
				return;
			}
			var c1 = new ContactsModel();
			var c2 = new ContactsModel();
			var c3 = new ContactsModel();
			c1.FirstName = "renan";
			c1.LastName = "Silva";
			c1.Telephone = "5555 - 1111";
			c1.Mail = "mail@mail.com";

			c2.FirstName = "joao";
			c2.LastName = "beaba";
			c2.Telephone = "5555 - 1111";
			c2.Mail = "mail@mail.com";

			c3.FirstName = "maria";
			c3.LastName = "bla";
			c3.Telephone = "5555 - 1111";
			c3.Mail = "mail@mail.com";

			AddContact(c1);
			AddContact(c2);
			AddContact(c3);
			isFirstTime = false;
		}
	}
}
