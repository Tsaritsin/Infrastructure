using System;
using Infrastructure.NET40.Tests.BindableViewModel;
using NUnit.Framework;
using System.Collections.Generic;

namespace Infrastructure.NET40.Tests
{
	[TestFixture]
	public class RaiseEventPropertyChangedTest
	{
		[Test]
		public void SetPropertyOnce_RaisedPropertyChanged()
		{
			#region Arrange

			var receivedEvents = new List<string>();
			var testObject = new PropertyChangedTesting();
			var expectedValueAfterRaised = "TestValue1";
			var actualValueAfterRaised = String.Empty;

			testObject.PropertyChanged += (sender, args) =>
			{
				receivedEvents.Add(args.PropertyName);
				actualValueAfterRaised = testObject.TestProp1;
			};

			#endregion

			#region Act

			testObject.TestProp1 = expectedValueAfterRaised;

			#endregion

			#region Assert

			Assert.That(receivedEvents.Count, Is.EqualTo(1), "Invalid count of rase event.");
			Assert.That(receivedEvents[0], Is.EqualTo("TestProp1"), "Invalid property name in raised event.");
			Assert.That(actualValueAfterRaised, Is.EqualTo(expectedValueAfterRaised), "Invalid property value in raised event.");

			#endregion
		}
	}
}
