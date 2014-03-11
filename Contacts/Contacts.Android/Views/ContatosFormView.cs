using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Views;
using Contacts.Android.Linked.ViewModels;

namespace Contacts.Android.Views
{
	[Activity(Label = "Form de contatos")]
	public class ContatosFormView : MvxActivity
	{

		private Button addContactButton;
		private Button cancelButton;
		private Button deleteButton;
		private EditText nameEditText;
		private EditText lastNameEditText;
		private EditText telephoneEditText;
		private EditText mailEditText;
		private string objectId;
		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.View_ContactForm);

			objectId = Intent.GetStringExtra("Model_ID");
			if (objectId != null) {
				Model.PopulateWithId(objectId);
			}

			addUIReferences();
			addBinds();
		}

		private void addUIReferences()
		{
			addContactButton = FindViewById<Button>(Resource.Id.idButtonAddContact);

			if (objectId == null) {
				addContactButton.Text = "Adicionar";
			}
			else {
				addContactButton.Text = "Atualizar";
			}

			cancelButton = FindViewById<Button>(Resource.Id.idButtonCancel);
			deleteButton = FindViewById<Button>(Resource.Id.idButtonDeleteContact);
			addContactButton.Click += (o, e) => { addContact(); };
			cancelButton.Click += (o, e) => { goToContactList(); };
			deleteButton.Click += (o, e) => { DeleteContact(); };

			nameEditText = FindViewById<EditText>(Resource.Id.editTextName);
			lastNameEditText = FindViewById<EditText>(Resource.Id.editTextLastName);
			telephoneEditText= FindViewById<EditText>(Resource.Id.editTextTelephone);
			mailEditText= FindViewById<EditText>(Resource.Id.editTextMail);

			if (objectId == null) {
				//todo:deveria remover o botao de remover se foss novo contato
			}

		}

		private void DeleteContact()
		{
			Model.DeleteContact(objectId);
			goToContactList();
		}

		private void addBinds()
		{
			var set = this.CreateBindingSet<ContatosFormView, ContatosFormViewModel>();
			set.Bind(nameEditText).For(nameEditText.Text).To(vm => vm.Name);
			set.Bind(lastNameEditText).For(lastNameEditText.Text).To(vm => vm.LastName);
			set.Bind(telephoneEditText).For(telephoneEditText.Text).To(vm => vm.Telephone);
			set.Bind(mailEditText).For(mailEditText.Text).To(vm => vm.Mail);
			set.Apply();
		}

		private ContatosFormViewModel Model {
			get { return (ContatosFormViewModel)ViewModel; }
		}

		private void addContact()
		{
			Toast.MakeText(this, "add contact clicked", ToastLength.Short).Show();
			if (objectId == null) {
				Model.AddContato();
			}
			else {
				Model.UpdateContato(objectId);
			}
			goToContactList();
		}

		private void goToContactList() {
			StartActivity(typeof(ContactsListView));
		}
	}
}