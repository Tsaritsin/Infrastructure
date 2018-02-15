using System;
using Harmony.Infrastructure.Common.ExtentionMethods;
using NUnit.Framework;

namespace Infrastructure.Common.NET40.Tests.ExtentionMethods
{
	[TestFixture]
	public class ObjectMethodsTests
	{
		[TestCase(null, "TestErrorMessage1", typeof(Exception), TestName = "ValueIsEmptyStringWaitException")]
		[TestCase("TestValue", null, null, TestName = "WithoutException")]
		[TestCase(null, "TestErrorMessage2", typeof(NullReferenceException), TestName = "WaitNullReferenceException")]
		public void SomeValue_CallThrowIfIsNull_GetException(
			object value, string errorMessage, Type expectedExceptionType)
		{
			#region Arrange

			Exception expectedException = null;
			if (expectedExceptionType != null)
				expectedException = (Exception)Activator.CreateInstance(expectedExceptionType, errorMessage);

			TestDelegate actionForTest = delegate
			{
				value.ThrowIfIsNull(expectedException);
			};

			#endregion

			#region Assert

			if (expectedExceptionType == null)
				Assert.DoesNotThrow(actionForTest);
			else
			{
				var actualExeption = Assert.Throws(Is.TypeOf(expectedExceptionType), actionForTest);
				Assert.That(actualExeption.Message, Is.EqualTo(errorMessage));
			}

			#endregion
		}

		[TestCase("TestValue", false, TestName = "ValueIsSampleString")]
		[TestCase(null, true, TestName = "ValueIsNull")]
		public void SomeValue_CallThrowIfArgumentIsNull_GetArgumentNullException(object value, bool exceptionIsExpected)
		{
			#region Arrange

			const string argumentName = "Argument1";

			TestDelegate actionForTest = delegate
			{
				value.ThrowIfArgumentIsNull(argumentName);
			};

			#endregion

			#region Assert

			if (exceptionIsExpected)
			{
				var actualExeption = Assert.Throws<ArgumentNullException>(actionForTest);

				StringAssert.Contains(argumentName, actualExeption.Message);
			}
			else
				Assert.DoesNotThrow(actionForTest);

			#endregion
		}

		[TestCase(null, "TestErrorMessage1", true, TestName = "ValueIsEmptyStringWaitException")]
		[TestCase("TestValue", "TestErrorMessage2", false, TestName = "WithoutException")]
		public void SomeValue_CallThrowIfIsNull_GetNullReferenceException(
			object value, string errorMessage, bool expectException)
		{
			#region Arrange
			
			TestDelegate actionForTest = delegate
			{
				value.ThrowIfIsNull(errorMessage);
			};

			#endregion

			#region Assert

			if (!expectException)
				Assert.DoesNotThrow(actionForTest);
			else
			{
				var actualExeption = Assert.Throws<NullReferenceException>(actionForTest);
				Assert.That(actualExeption.Message, Is.EqualTo(errorMessage));
			}

			#endregion
		}

	}
}
