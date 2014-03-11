using System.Collections.Generic;
using Contacts.Core.Models;

namespace Contacts.Core.Services
{
	public interface IDataService
	{
		List<Contact> FindContact(string nameFilter);
		void Insert(Contact model);
		void Update(Contact model);
		void Delete(Contact model);
	}
}