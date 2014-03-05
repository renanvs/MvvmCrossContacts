using System;

namespace Contacts.Core.Models
{
	public class ContactsModel
	{
		private string firstName;
		private string lastName;

		public ContactsModel()
		{
			
		}

		public ContactsModel(String _firstName, String _lastName)
		{
			firstName = _firstName;
			lastName = _lastName;

		}

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}

		public string FullName
		{
			get { return string.Format("{0} {1}", firstName, lastName); }
		}

	}
}
