using System;

namespace Harmony.Infrastructure.MVVM
{
	public class DependencyFromPropertyAttribute : Attribute
	{
		public DependencyFromPropertyAttribute(string propertyName)
		{
			if (String.IsNullOrEmpty(propertyName))
				throw new ArgumentNullException(nameof(propertyName));
			PropertyName = propertyName;
		}

		public string PropertyName { get; }
	}
}
