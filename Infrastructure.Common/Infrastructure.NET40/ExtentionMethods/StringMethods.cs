using System;

namespace Harmony.Infrastructure.Common.ExtentionMethods
{
	/// <summary>
	/// Contains extention method for string's value
	/// </summary>
	public static class StringMethods
	{
		/// <summary>
		/// Implement functional of method <see cref="String.IsNullOrEmpty"/>.
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <returns></returns>
		public static bool IsNullOrEmpty(this string value)
		{
			var result = String.IsNullOrEmpty(value);
			return result;
		}

		/// <summary>
		/// Throw exception is value equals null or Empty.
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <param name="exception">The exception to throw.</param>
		public static string ThrowIfIsNullOrEmpty(this string value, Exception exception)
		{
			if (String.IsNullOrEmpty(value))
				throw exception;
			return value;
		}

		/// <summary>
		/// Throw exception (InvalidOperationException) is value equals null or Empty.
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <param name="errorMessage">The message for exception to throw.</param>
		public static string ThrowIfIsNullOrEmpty(this string value, string errorMessage)
		{
			if (String.IsNullOrEmpty(value))
				throw new InvalidOperationException(errorMessage);
			return value;
		}

		/// <summary>
		/// Throw exception (ArgumentException) if argument is equals null or Empty.
		/// </summary>
		/// <param name="value">The argument to test.</param>
		public static string ThrowIfArgumentIsNullOrEmpty(this string value)
		{
			if (String.IsNullOrEmpty(value))
				throw new ArgumentException(String.Format("Argument [{0}] is empty", value));
			return value;
		}
	}
}
