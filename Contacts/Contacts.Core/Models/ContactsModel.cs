using System;

namespace Contacts.Core.Models
{
	public class ContactsModel
	{
		private string firstName;
		private string lastName;
		private string telephone;
		private string mail;

		public ContactsModel(String _firstName, String _lastName, String _telephone = "", String _mail = "")
		{
			firstName = _firstName;
			lastName = _lastName;
			telephone = _telephone;
			mail = _mail;
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

		public string Telephone
		{
			get { return telephone; }
			set { telephone = value; }
		}

		public string Mail
		{
			get { return mail; }
			set { mail = value; }
		}

	}
}
