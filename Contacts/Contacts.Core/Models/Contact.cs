using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;

namespace Contacts.Core.Models
{
	public class Contact
	{
		[PrimaryKey, AutoIncrement]
		public string id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Telephone { get; set; }
		public string Mail { get; set; }
	}
}
