using System;
using Harmony.Infrastructure.Common.ExtentionMethods;

namespace Harmony.Infrastructure.MVVM
{
	public class DependencyFromPropertyAttribute : Attribute
	{
		public DependencyFromPropertyAttribute(string propertyName)
		{
			PropertyName = propertyName.ThrowIfArgumentIsNullOrEmpty(nameof(propertyName));
		}

		public string PropertyName { get; }
	}
}
