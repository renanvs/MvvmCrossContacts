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
		private EditText nameEditText;
		private EditText lastNameEditText;
		private EditText telephoneEditText;
		private EditText mailEditText;
		
		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.View_ContactForm);

			addUIReferences();
			addBinds();
		}

		private void addUIReferences()
		{
			addContactButton = FindViewById<Button>(Resource.Id.idButtonAddContact);
			cancelButton = FindViewById<Button>(Resource.Id.idButtonCancel);
			addContactButton.Click += (o, e) => { addContact(); };
			cancelButton.Click += (o, e) => { goToContactList(); };

			nameEditText = FindViewById<EditText>(Resource.Id.editTextName);
			lastNameEditText = FindViewById<EditText>(Resource.Id.editTextLastName);
			telephoneEditText= FindViewById<EditText>(Resource.Id.editTextTelephone);
			mailEditText= FindViewById<EditText>(Resource.Id.editTextMail);
			
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
			Model.AddContato();
			goToContactList();
		}

		private void goToContactList() {
			StartActivity(typeof(ContactsListView));
		}
	}
}