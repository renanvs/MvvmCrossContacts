using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Binding.ExtensionMethods;
using Cirrious.MvvmCross.Droid.Views;
using Contacts.Core.Models;
using Contacts.Core.Services;

namespace Contacts.Android.Views
{
	[Activity(Label = "Lista de contatos", MainLauncher = true)]
	public class ContactsListView : MvxActivity
	{

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.View_ListContacts);

			var contactsListView = (MvxListView)FindViewById(Resource.Id.idContactList);

			List<ContactsModel> itens = ContactsService.Instance.GetAllContacts();
			contactsListView.Adapter = new CustomAdapter(this, itens);
			
		}

		protected override void OnViewModelSet()
		{
			//var contactsListView = (MvxListView)FindViewById(Resource.Id.idContactList);
			
			//var itens = new string[] { "1", "2", "3" };
			//contactsListView.Adapter = new CustomAdapter(this, itens);
		}

	}

	public class CustomAdapter : BaseAdapter<ContactsModel>, IMvxAdapter
	{
		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;

			if (view == null) {
				view = activity.LayoutInflater.Inflate(Resource.Layout.View_CellContato, parent, false);
				var item = itens[position];
				view.FindViewById<TextView>(Resource.Id.idName).Text = item.FirstName;
				view.FindViewById<TextView>(Resource.Id.idLastName).Text = item.LastName;
				view.FindViewById<TextView>(Resource.Id.idFullName).Text = item.FullName;
				return view;
			}

			return view;
		}

		public override int Count
		{
			get { return itens.Count; }
		}

		List<ContactsModel> itens;
		Activity activity;

		public CustomAdapter(Activity context, List<ContactsModel> itens)
			: base()
		{
			this.itens = itens;
			this.activity = context;
		}

		public object GetRawItem(int position)
		{
			return itens[position];
		}

		public int GetPosition(object value)
		{
			return itens.GetPosition(value);
		}

		public int SimpleViewLayoutId { get; set; }
		public IEnumerable ItemsSource { get; set; }
		public int ItemTemplateId { get; set; }
		public int DropDownItemTemplateId { get; set; }

		public override ContactsModel this[int position]
		{
			get { 
				return itens[position]; 
			}
		}
	}
}