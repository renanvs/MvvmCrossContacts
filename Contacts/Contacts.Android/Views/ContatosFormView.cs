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

namespace Contacts.Android.Views
{
	[Activity(Label = "Form de contatos")]
	public class ContatosFormView : Activity
	{

		private Button addContactButton;
		private Button cancelButton;
		private EditText nameEditText;
		
		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.View_ContactForm);

			// Create your application here
		}
	}
}