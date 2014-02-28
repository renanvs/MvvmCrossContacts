using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core
{
	public class ContactsModel
	{
		private static string name;
		private static string lastName;

		public ContactsModel(string n)
		{
			name = n;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}

		public void printFullName()
		{
			Console.WriteLine("{0} {1}", name, lastName);
		}

	}
}
