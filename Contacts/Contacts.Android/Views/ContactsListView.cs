using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Binding.ExtensionMethods;
using Cirrious.MvvmCross.Droid.Views;
using Contacts.Core.Models;
using Contacts.Core.Services;
using Contacts.Core.ViewModels;

namespace Contacts.Android.Views
{
	[Activity(Label = "Lista de contatos", MainLauncher = true)]
	public class ContactsListView : MvxActivity
	{

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.View_ListContacts);

			AddButtonListening();

		}

		private void AddButtonListening()
		{
			Button bt = (Button) FindViewById(Resource.Id.idButtonAdd);
			bt.Click += (o, e) => {
				Toast.MakeText(this, "clicked", ToastLength.Short).Show();
				addContatoFake();
			};
		}

		private ContactsListViewModel Model
		{
			get { return (ContactsListViewModel) ViewModel; }
		}


		static private string fakeName = "fakeName";
		static private string fakeLastName = "fakeLastname";
		private int auxNum = 0;
		public void addContatoFake()
		{
			var newFakeName = fakeName + auxNum.ToString();
			var newFakeLastName = fakeLastName + auxNum.ToString();
			auxNum++;
			var newModel = new ContactsModel(newFakeName, newFakeLastName);
			Model.AddContato(newModel);
			MvxListView listView = FindViewById<MvxListView>(Resource.Id.idListView);
			listView.InvalidateViews();
		}

	}

}