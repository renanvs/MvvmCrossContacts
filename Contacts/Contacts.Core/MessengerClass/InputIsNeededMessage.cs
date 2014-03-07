using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace Contacts.Core.MessengerClass
{
	public class InputIsNeededMessage : MvxMessage
	{
		public InputIsNeededMessage(object sender)
			: base(sender) {

		}
	}
}
