using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.IO
{
	public abstract class DeviceFileSystem :IDeviceFileSystem
	{

		public abstract string DataBasePath();

	}
}
