using System;

namespace Harmony.Infrastructure.Common.ExtenstionMethods
{
	/// <summary>
	/// Contains extenstion method for string's value
	/// </summary>
	public static class StringMethods
	{
		/// <summary>
		/// Implement functional of method <see cref="String.IsNullOrEmpty"/> and <see cref="String.IsNullOrWhiteSpace"/>.
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <returns></returns>
		public static bool IsEmpty(this string value)
		{
			var isEmpty = 
					String.IsNullOrEmpty(value) ||
					String.IsNullOrWhiteSpace(value);
			return isEmpty;
		}

		/// <summary>
		/// If value is empty then return newValue
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <param name="newValue">It return if value is empty</param>
		/// <returns>if value is empty then return newValue else return value</returns>
		public static string IsEmpty(this string value, string newValue)
		{
			return value.IsEmpty() ? newValue : value;
		}

		/// <summary>
		/// Invert result of method IsEmpty(this string value)
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <returns></returns>
		public static bool HasValue(this string value)
		{
			return !value.IsEmpty();
		}

		/// <summary>
		/// Throw exception if value is empty
		/// </summary>
		/// <param name="value">The string to test</param>
		/// <param name="exception">The exception to throw</param>
		public static string ThrowIfIsEmpty(this string value, Exception exception)
		{
			if (value.IsEmpty())
				throw exception;
			return value;
		}

		/// <summary>
		/// Throw InvalidOperationException if value is empty
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <param name="errorMessage">The message for exception to throw.</param>
		public static string ThrowIfIsEmpty(this string value, string errorMessage)
		{
			if (value.IsEmpty())
				throw new InvalidOperationException(errorMessage);
			return value;
		}

		/// <summary>
		/// Throw exception (ArgumentException) if value is empty
		/// </summary>
		/// <param name="value">The argument to test.</param>
		/// <param name="argumentName">Name of argument to test.</param>
		public static string ThrowIfArgumentIsNullOrEmpty(this string value, string argumentName)
		{
			if (value.IsEmpty())
				throw new ArgumentNullException(argumentName, $"Argument [{argumentName}] is empty");
			return value;
		}
	}
}
