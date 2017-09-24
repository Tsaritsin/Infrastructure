using System;
using Harmony.Infrastructure.Common.ExtentionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.Common.SL5.Tests.ExtentionMethods
{
	[TestClass]
	public class StringMethodsTests
	{
		[TestMethod]
		public void IsNullOrEmpty_Cases()
		{
			#region Arrange

			var testData = new []
			{
				new { Value = "", ExpectedResult = true, TestName = "ValueIsEmptyString" },
				new { Value = "TestValue", ExpectedResult = false, TestName = "ValueIsSampleString" },
				new { Value = (string)null, ExpectedResult = true, TestName = "ValueIsNull" },
				new { Value = Environment.NewLine, ExpectedResult = false, TestName = "ValueIsNewLine" }
			};

			#endregion

			foreach (var testValue in testData)
			{
				// Act
				var actualResult = testValue.Value.IsNullOrEmpty();
				// Assert
				Assert.AreEqual(testValue.ExpectedResult, actualResult, $"Invalid Result in case {testValue.TestName}");
			}
		}
		
			//[TestCase("", "TestErrorMessage1", true, TestName = "ValueIsEmptyString")]
			//[TestCase("TestValue", null, false, TestName = "ValueIsSampleString")]
			//[TestCase(null, "TestErrorMessage2", true, TestName = "ValueIsNull")]
			//[TestCase("\n", null, false, TestName = "ValueIsNewLine")]
			//public void ThrowIfIsNullOrEmpty_SetErrorMessage_Cases(
			//	string value, string errorMessage, bool exceptionIsExpected)
			//{
			//	#region Arrange

			//	TestDelegate actionForTest  = delegate 
			//	{
			//		value.ThrowIfIsNullOrEmpty(errorMessage);
			//	};

			//	#endregion

			//	#region Assert

			//	if (exceptionIsExpected)
			//	{
			//		var actualExeption = Assert.Throws<InvalidOperationException>(actionForTest);
			//		Assert.That(actualExeption.Message, Is.EqualTo(errorMessage));
			//	}
			//	else
			//		Assert.DoesNotThrow(actionForTest);

			//	#endregion
			//}

			//[TestCase("", "TestErrorMessage1", typeof(Exception), TestName = "ValueIsEmptyStringWaitException")]
			//[TestCase("TestValue", null, null, TestName = "WithoutException")]
			//[TestCase(null, "TestErrorMessage2", typeof(NullReferenceException), TestName = "WaitNullReferenceException")]
			//[TestCase("\n", null, null, TestName = "ValueIsNewLineWithoutException")]
			//public void ThrowIfIsNullOrEmpty_SetException_Cases(
			//	string value, string errorMessage, Type expectedExceptionType)
			//{
			//	#region Arrange

			//	Exception expectedException = null;
			//	if (expectedExceptionType != null)
			//		expectedException = (Exception)Activator.CreateInstance(expectedExceptionType, errorMessage);

			//	TestDelegate actionForTest = delegate
			//	{
			//		value.ThrowIfIsNullOrEmpty(expectedException);
			//	};

			//	#endregion

			//	#region Assert

			//	if (expectedExceptionType == null)
			//		Assert.DoesNotThrow(actionForTest);
			//	else
			//	{
			//		var actualExeption = Assert.Throws(Is.TypeOf(expectedExceptionType), actionForTest);
			//		Assert.That(actualExeption.Message, Is.EqualTo(errorMessage));
			//	}

			//	#endregion
			//}

			//[TestCase("", true, TestName = "ValueIsEmptyString")]
			//[TestCase("TestValue", false, TestName = "ValueIsSampleString")]
			//[TestCase(null, true, TestName = "ValueIsNull")]
			//[TestCase("\n", false, TestName = "ValueIsNewLine")]
			//public void ThrowIfArgumentIsNullOrEmpty_Cases(string value, bool exceptionIsExpected)
			//{
			//	#region Arrange

			//	const string argumentName = "Argument1";

			//	TestDelegate actionForTest = delegate
			//	{
			//		value.ThrowIfArgumentIsNullOrEmpty(argumentName);
			//	};

			//	#endregion

			//	#region Assert

			//	if (exceptionIsExpected)
			//	{
			//		var actualExeption = Assert.Throws<ArgumentNullException>(actionForTest);

			//		StringAssert.Contains(argumentName, actualExeption.Message);
			//	}
			//	else
			//		Assert.DoesNotThrow(actionForTest);

			//	#endregion
			//}

		}
}
