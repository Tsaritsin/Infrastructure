using System;

namespace Harmony.Infrastructure.Common.ExtentionMethods
{
	/// <summary>
	/// Contains extention method for object's value
	/// </summary>
	public static class ObjectMethods
	{
		/// <summary>
		/// Throw exception is value equals null.
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
		/// Throw exception (ArgumentException) if argument is equals null
		/// </summary>
		/// <param name="value">The argument to test.</param>
		/// <param name="argumentName">Name of argument to test.</param>
		public static T ThrowIfArgumentIsNull<T>(this T value, string argumentName)
		{
			if (value == null)
				throw new ArgumentNullException($"Argument [{argumentName}] is null");
			return value;
		}
	}
}
