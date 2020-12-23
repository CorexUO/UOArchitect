using System;

namespace OrbServerSDK
{
	[Serializable]
	public enum LoginCodes
	{
		Success = 0,
		InvalidAccount = 1,
		NotAuthorized = 2,
		ConnectionFailure = 3
	}

	[Serializable]
	public struct LoginResult
	{
		public readonly LoginCodes Code;
		public readonly string ErrorMessage;
		public readonly Exception LoginException;

		internal LoginResult(LoginCodes code) : this(code, null, null)
		{
		}

		internal LoginResult(LoginCodes code, string errorMessage) : this(code, errorMessage, null)
		{
		}

		internal LoginResult(LoginCodes code, string errorMessage, Exception e)
		{
			Code = code;
			ErrorMessage = errorMessage;
			LoginException = e;
		}
	}
}
