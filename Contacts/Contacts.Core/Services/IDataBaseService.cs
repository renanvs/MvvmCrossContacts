using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contacts.Core.Models;

namespace SqlSample.Core.Services
{
	public interface IDataBaseService
	{
		void insertContactInDb(ContactsModel model);
		void updateContentInDb(ContactsModel model);
		List<ContactsModel> getAllContacts();
		ContactsModel getModelWithId(string id);
		bool hasSample();
	}
}
