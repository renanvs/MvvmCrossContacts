using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using Contacts.Android.Linked.ViewModels;
using Contacts.Core.MessengerClass;
using Contacts.Core.Models;
using Contacts.Core.Services;

namespace Contacts.Core.ViewModels
{
	public class ContactsListViewModel : MvxViewModel
	{

		private readonly IContactsService _contactsService;
		/// <summary>
		/// Ao criar o ViewModel (apenas uma vez), é criado alguns contatos de teste e enviado para a lista
		/// </summary>
		/// <param name="contactsService"></param>
		public ContactsListViewModel(IContactsService contactsService)
		{
			_contactsService = contactsService;
			
		}

		/// <summary>
		/// Label do botão que adiciona os contatos (via Binding)
		/// </summary>
		public string AddButtonLabel {
			get { return "Add Contatos"; }
		}

		/// <summary>
		/// Lista de todos os contatos (via Binding)
		/// </summary>
		public List<ContactsModel> ListContatos
		{
			get
			{
				return _contactsService.GetAllContacts();
				
			}
		}

		/// <summary>
		/// Recebe o Model de contato da camada UI e envia para o service que se encarrega de armazenar, 
		/// logo após é enviado uma notificação que a Lista de contatos foi atualizada
		/// </summary>
		/// <param name="model"></param>
		public void AddContato(ContactsModel model)
		{
			_contactsService.AddContact(model);
			RaisePropertyChanged(()=>ListContatos);
		}

		public ICommand ShowContactDetailCommand
		{
			get
			{
				return new MvxCommand<ContactsModel>(contactModel => ShowDetailContactView(contactModel));
			}
		}

		public void ShowDetailContactView(ContactsModel model)
		{
			var messenger = Mvx.Resolve<IMvxMessenger>();
			messenger.Publish(new InputIsNeededMessage(model));
		}

	}
}
