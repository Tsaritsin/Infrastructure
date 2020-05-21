using System;

namespace Harmony.Infrastructure.Common.ExtenstionMethods
{
	/// <summary>
	/// Contains extenstion method for object's value
	/// </summary>
	public static class ObjectMethods
	{
		/// <summary>
		/// Throw exception if value equals null.
		/// </summary>
		/// <param name="value">The object to test.</param>
		/// <param name="exception">The exception to throw.</param>
		public static T ThrowIfIsNull<T>(this T value, Exception exception)
		{
			if (value == null)
				throw exception;
			return value;
		}

		/// <summary>
		/// Throw NullReferenceException if value equals null.
		/// </summary>
		/// <param name="value">The object to test.</param>
		/// <param name="exceptionMessage">The message of NullReferenceException for throw.</param>
		public static T ThrowIfIsNull<T>(this T value, string exceptionMessage)
		{
			if (String.IsNullOrEmpty(exceptionMessage))
				throw new ArgumentNullException(nameof(exceptionMessage));

			if (value == null)
				throw new NullReferenceException(exceptionMessage);

			return value;
		}

		/// <summary>
		/// Throw exception (ArgumentException) if argument is equals null
		/// </summary>
		/// <param name="value">The argument to test.</param>
		/// <param name="argumentName">Name of argument to test.</param>
		public static T ThrowIfArgumentIsNull<T>(this T value, string argumentName)
		{
			if (value == null)
				throw new ArgumentNullException(argumentName, $"Argument [{argumentName}] is null");
			return value;
		}
	}
}
