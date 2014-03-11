using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contacts.Core.IO;
using Contacts.Core.Models;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;

namespace SqlSample.Core.Services
{
	public class DataBaseService : IDataBaseService
	{
	
		/*public DataBaseService(string path) : base(new SQLitePlatformAndroid(), path)
		{
			CreateTable<Pessoa>();
		}*/

		SQLiteConnection _sqliteConnection;

		private IDeviceFileSystem _fs;
		public DataBaseService(IDeviceFileSystem fs)
		{
			_fs = fs;

			var dbPath = _fs.DataBasePath();

			_sqliteConnection = new SQLiteConnection(new SQLitePlatformAndroid(), dbPath);
			_sqliteConnection.CreateTable<ContactsModel>();
		}

		public void insertContactInDb(ContactsModel contact)
		{

			var s = _sqliteConnection.Insert(contact);
			
		}

		public void updateContentInDb(ContactsModel model)
		{
			_sqliteConnection.Update(model);
		}

		public List<ContactsModel> getAllContacts() {
			var s = _sqliteConnection.Table<ContactsModel>().ToList();
			return s;
		}

		public ContactsModel getModelWithId(string id)
		{
			var idInt = Convert.ToInt32(id);
			var s = _sqliteConnection.Table<ContactsModel>().LastOrDefault(v => v.IdContact.Equals(idInt));
			return s;
		}

		public bool hasSample()
		{
			var s = _sqliteConnection.Table<ContactsModel>().Where(v => v.FirstName.Equals("renan")).LastOrDefault();

			if (s == null) {
				return false;
			}

			return true;
		}

		public void deleteContentInDb(ContactsModel model)
		{
			_sqliteConnection.Delete(model);
		}
	}
}
