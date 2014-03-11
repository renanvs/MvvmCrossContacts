using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using Contacts.Core.Models;

namespace Contacts.Core.Services
{
	public class DataService : IDataService
	{

		private readonly ISQLiteConnection _connection;

		public DataService(ISQLiteConnectionFactory factory)
		{
			_connection = factory.Create("contacts.sql");
			_connection.CreateTable<Contact>();
			//CreateSampleContacts();
		}

		private static bool isFirstTime = true;
		private void CreateSampleContacts()
		{
			if (!isFirstTime) {
				return;
			}
			var c1 = new Contact();
			c1.FirstName = "Renan";
			c1.LastName = "Silva";

			var c2 = new Contact();
			c2.FirstName = "Joao";
			c2.LastName = "Bla";

			var c3 = new Contact();
			c3.FirstName = "Maria";
			c3.LastName = "Ble";
			
			Insert(c1);
			Insert(c2);
			Insert(c3);

			isFirstTime = false;
		}

		public List<Contact> FindContact(string nameFilter)
		{
			return _connection.Table<Contact>().OrderBy(x => x.FirstName).Where(x => x.FirstName.Contains(nameFilter)).ToList();
		}

		public void Insert(Contact model)
		{
			_connection.Insert(model);
		}

		public void Update(Contact model)
		{
			_connection.Update(model);
		}

		public void Delete(Contact model)
		{
			_connection.Delete(model);
		}
	}
}
