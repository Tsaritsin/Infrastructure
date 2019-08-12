using System;
using Harmony.Infrastructure.Common.ExtenstionMethods;
using NUnit.Framework;

namespace Infrastructure.Common.NET40.Tests.ExtenstionMethods
{
	[TestFixture]
	public class StringMethodsTests
	{
		[TestCase("", true, TestName = "ValueIsEmptyString")]
		[TestCase("TestValue", false, TestName = "ValueIsSampleString")]
		[TestCase(null, true, TestName = "ValueIsNull")]
		[TestCase("\n", false, TestName = "ValueIsNewLine")]
		public void IsNullOrEmpty_Cases(string value, bool expectedResult)
		{
			#region Act
			
			var actualResult = value.IsNullOrEmpty();

			#endregion

			#region Assert

			Assert.That(actualResult, Is.EqualTo(expectedResult));

			#endregion
		}

		[TestCase("", false, TestName = "ValueIsEmptyString")]
		[TestCase("TestValue", true, TestName = "ValueIsSampleString")]
		[TestCase(null, false, TestName = "ValueIsNull")]
		[TestCase("\n", true, TestName = "ValueIsNewLine")]
		public void HasValue_Cases(string value, bool expectedResult)
		{
			#region Act

			var actualResult = value.HasValue();

			#endregion

			#region Assert

			Assert.That(actualResult, Is.EqualTo(expectedResult));

			#endregion
		}

		[TestCase("", "n1", "n1", TestName = "ValueIsEmptyString")]
		[TestCase("TestValue", "n2", "TestValue", TestName = "ValueIsSampleString")]
		[TestCase(null, "n3", "n3", TestName = "ValueIsNull")]
		[TestCase("\n", "n4", "\n", TestName = "ValueIsNewLine")]
		public void SetValueIfIsNullOrEmpty_Cases(string value, string newValue, string expectedResult)
		{
			#region Act

			var actualResult = value.SetValueIfIsNullOrEmpty(newValue);

			#endregion

			#region Assert

			Assert.That(actualResult, Is.EqualTo(expectedResult));

			#endregion
		}

		[TestCase("", "TestErrorMessage1", true, TestName = "ValueIsEmptyString")]
		[TestCase("TestValue", null, false, TestName = "ValueIsSampleString")]
		[TestCase(null, "TestErrorMessage2", true, TestName = "ValueIsNull")]
		[TestCase("\n", null, false, TestName = "ValueIsNewLine")]
		public void ThrowIfIsNullOrEmpty_SetErrorMessage_Cases(
			string value, string errorMessage, bool exceptionIsExpected)
		{
			#region Arrange

			TestDelegate actionForTest  = delegate 
			{
				value.ThrowIfIsNullOrEmpty(errorMessage);
			};

			#endregion

			#region Assert

			if (exceptionIsExpected)
			{
				var actualExeption = Assert.Throws<InvalidOperationException>(actionForTest);
				Assert.That(actualExeption.Message, Is.EqualTo(errorMessage));
			}
			else
				Assert.DoesNotThrow(actionForTest);
			
			#endregion
		}

		[TestCase("", "TestErrorMessage1", typeof(Exception), TestName = "ValueIsEmptyStringWaitException")]
		[TestCase("TestValue", null, null, TestName = "WithoutException")]
		[TestCase(null, "TestErrorMessage2", typeof(NullReferenceException), TestName = "WaitNullReferenceException")]
		[TestCase("\n", null, null, TestName = "ValueIsNewLineWithoutException")]
		public void ThrowIfIsNullOrEmpty_SetException_Cases(
			string value, string errorMessage, Type expectedExceptionType)
		{
			#region Arrange

			Exception expectedException = null;
			if (expectedExceptionType != null)
				expectedException = (Exception)Activator.CreateInstance(expectedExceptionType, errorMessage);

			TestDelegate actionForTest = delegate
			{
				value.ThrowIfIsNullOrEmpty(expectedException);
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

		[TestCase("", true, TestName = "ValueIsEmptyString")]
		[TestCase("TestValue", false, TestName = "ValueIsSampleString")]
		[TestCase(null, true, TestName = "ValueIsNull")]
		[TestCase("\n", false, TestName = "ValueIsNewLine")]
		public void ThrowIfArgumentIsNullOrEmpty_Cases(string value, bool exceptionIsExpected)
		{
			#region Arrange

			const string argumentName = "Argument1";

			TestDelegate actionForTest = delegate
			{
				value.ThrowIfArgumentIsNullOrEmpty(argumentName);
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

	}
}
