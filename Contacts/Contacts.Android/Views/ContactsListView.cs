using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Plugins.Messenger;
using Contacts.Core.MessengerClass;
using Contacts.Core.Models;
using Contacts.Core.ViewModels;
using Java.IO;

namespace Contacts.Android.Views
{
	[Activity(Label = "Lista de contatos", MainLauncher = true)]
	public class ContactsListView : MvxActivity
	{

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.View_ListContacts);

			var messeger = Mvx.Resolve<IMvxMessenger>();
 			var _token = messeger.SubscribeOnMainThread<InputIsNeededMessage>(receiveMessageHandler);

			AddButtonsEvent();
		}

		private void receiveMessageHandler(InputIsNeededMessage message)
		{
			var model = (ContactsModel) message.Sender;
			GoToFormActivityWithModel(model);
			
		}

		/// <summary>
		/// Cria um Evento para o botão de adicionar contatos
		/// </summary>
		private void AddButtonsEvent()
		{
			Button ButtonAddFakeContact = (Button) FindViewById(Resource.Id.idButtonAdd);
			ButtonAddFakeContact.Click += (o, e) => {
				Toast.MakeText(this, "clicked", ToastLength.Short).Show();
				addContatoFake();
			};

			Button ButtonGoToForm = FindViewById<Button>(Resource.Id.idButtonGoToForm);
			ButtonGoToForm.Click += (o, e) => { GoToFormActivity(); };
		}

		/// <summary>
		/// Vai para o Formulario de adicionar contato
		/// </summary>
		private void GoToFormActivity()
		{
			StartActivity(typeof(ContatosFormView));
		}

		private void GoToFormActivityWithModel(ContactsModel modelC)
		{
			var activity = new Intent(this, typeof(ContatosFormView));
			activity.PutExtra("Model_ID", modelC.IdContact.ToString());
			StartActivity(activity);
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
			var newModel = new ContactsModel();
			newModel.FirstName = newFakeName;
			newModel.LastName = newFakeLastName;
			newModel.Telephone = "5566 - 6666";
			newModel.Mail = "fakeMail@fame.com";
			Model.AddContato(newModel);
			MvxListView listView = FindViewById<MvxListView>(Resource.Id.idListView);
			listView.InvalidateViews();
		}

	}

}