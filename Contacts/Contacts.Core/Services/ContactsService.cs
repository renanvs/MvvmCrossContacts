using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Core.Models;

namespace Contacts.Core.Services
{
	public class ContactsService
	{
		public ContactsService()
		{
			Console.WriteLine("ContactsService Called");
			
		}

		static ContactsService instance = null;
		static readonly object padlock = new object();
		public static ContactsService Instance
		{
			get
			{
				lock (padlock) {
					if(instance == null) {
						instance = new ContactsService();
						firstTime = true;
						if (contactList == null) {
							contactList = new List<ContactsModel>();
						}
						instance.CreateTestContacts();
						Console.WriteLine("Instance Called");
					}
					return instance;
				}
			}

		}

		private static bool firstTime;

		private void CreateTestContacts()
		{
			if (!firstTime) {
				return;
			}
			
			var c1 = new ContactsModel("renan", "silva");
			var c2 = new ContactsModel("joao", "sub1");
			var c3 = new ContactsModel("maria", "sub2");

			AddContact(c1);
			AddContact(c2);
			AddContact(c3);

			firstTime = false;
		}

		private static List<ContactsModel> contactList;

		public void AddContact(ContactsModel ContactModel)
		{
			contactList.Add(ContactModel);
		}

		public void PrintListToConsole()
		{
			foreach (var c in contactList) {
				Console.WriteLine("Contato na posição {0}", contactList.IndexOf(c));
				Console.WriteLine("{0} {1}", c.FirstName, c.LastName);
				Console.WriteLine("---------------");
			}
		}

		public List<ContactsModel> GetAllContacts()
		{
			return contactList;
		} 
	}
}
