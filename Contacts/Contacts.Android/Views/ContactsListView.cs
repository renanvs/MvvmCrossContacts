using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Droid.Views;
using Contacts.Core.Models;
using Contacts.Core.ViewModels;

namespace Contacts.Android.Views
{
	[Activity(Label = "Lista de contatos", MainLauncher = true)]
	public class ContactsListView : MvxActivity
	{

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.View_ListContacts);

			AddButtonEvent();

		}

		/// <summary>
		/// Cria um Evento para o botão de adicionar contatos
		/// </summary>
		private void AddButtonEvent()
		{
			Button bt = (Button) FindViewById(Resource.Id.idButtonAdd);
			bt.Click += (o, e) => {
				Toast.MakeText(this, "clicked", ToastLength.Short).Show();
				addContatoFake();
			};
		}

		/// <summary>
		/// Retorna a istancia do ViewModel
		/// </summary>
		private ContactsListViewModel Model
		{
			get { return (ContactsListViewModel) ViewModel; }
		}

		/// <summary>
		/// Cria contatos falsos para simular a adição de contatos
		/// </summary>
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