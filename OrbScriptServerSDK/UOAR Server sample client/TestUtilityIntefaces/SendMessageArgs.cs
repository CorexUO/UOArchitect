using System;
using OrbServerSDK;

namespace TestUtilityIntefaces
{
	// define class used to send parameters to the scripted SendMessage Command
	// the base class doesn't contain any fields or methods.

	[Serializable] // *** REQUIRED ***
	public class SendMessageArgs : OrbCommandArgs
	{
		private string _message;

		public SendMessageArgs(string message)
		{
			_message = message;
		}

		public string Message
		{
			get{ return _message; }
			set{ _message = value; }
		}
	}
}
