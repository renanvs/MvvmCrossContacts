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
using Cirrious.CrossCore.Platform;

namespace Contacts.Android
{
	class _DebugTrace : IMvxTrace
	{
		public void Trace(MvxTraceLevel level, string tag, Func<string> message) {
			System.Diagnostics.Debug.WriteLine("fromAndroid: " + tag + ":" + level + ":" + message());
		}

		public void Trace(MvxTraceLevel level, string tag, string message) {
			System.Diagnostics.Debug.WriteLine("fromAndroid: " + tag + ":" + level + ":" + message);
		}

		public void Trace(MvxTraceLevel level, string tag, string message, params object[] args) {
			try {
				System.Diagnostics.Debug.WriteLine(string.Format("fromAndroid: " + tag + ":" + level + ":" + message, args));
			}
			catch (FormatException) {
				Trace(MvxTraceLevel.Error, tag, "Exception during trace of {0} {1} {2}", level, message);
			}
		}
	}
}