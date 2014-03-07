using System;
using System.Runtime.Serialization;

namespace Contacts.Core.Models
{
	public class ContactsModel
	{
		private string firstName;
		private string lastName;
		private string telephone;
		private string mail;
		private string idContact;

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

		public string IdContact {
			get { return idContact; }
			set { idContact = value; }
		}

		/// <summary>
		/// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the target object.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data. </param><param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization. </param><exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
		public void GetObjectData(SerializationInfo info, StreamingContext context) {}
	}
}
