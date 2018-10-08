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
		/// If value is null or empty then will return newValue
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <param name="newValue">It will return if value is null or empty</param>
		/// <returns>if value is null or empty then will return newValue else will return value</returns>
		public static string SetValueIfIsNullOrEmpty(this string value, string newValue)
		{
			var isNullOrEmpty = String.IsNullOrEmpty(value);
			var result = isNullOrEmpty ? newValue : value;
			return result;
		}

		/// <summary>
		/// Invert result of method <see cref="String.IsNullOrEmpty"/>.
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <returns></returns>
		public static bool HasValue(this string value)
		{
			var result = !String.IsNullOrEmpty(value);
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
		/// <param name="argumentName">Name of argument to test.</param>
		public static string ThrowIfArgumentIsNullOrEmpty(this string value, string argumentName)
		{
			if (String.IsNullOrEmpty(value))
				throw new ArgumentNullException($"Argument [{argumentName}] is empty");
			return value;
		}
	}
}
